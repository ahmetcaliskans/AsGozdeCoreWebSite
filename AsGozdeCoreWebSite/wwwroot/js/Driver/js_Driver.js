/***** Id ile şube tanımı getirilir *****/
function js_getDriverByIdWithDetails(Id) {
	$('#dataDriver').html("");


	$.ajax({
		async: true,
		type: "GET",
		url: "/Driver/GetDriverByIdWithDetails",
		data: { id: Id },
		contentType: "application/json; charset=utf-8",
		dataType: "html",
		success: function (data) {
			var result = data;
			//$('#dataDriver').html("");
			//$('#dataDriver').html(result);
		},
		error: function (err) {
			mesajBox('mesaj', 'UYARI', err.responseText, 'warning');
		}
	});
}

/** Silme işlemi öncesi kullanıcıya son ikaz yapılır */
function js_deleteDriverByIdQ(Id) {
	if (Id > 0) {
		mesajBox_confirm('Sil', 'Sil', 'Tanımı Silmek İstediğinize Emin misiniz ?', 'Sil', 'danger', 'js_deleteDriverById(' + Id + ')');
	}

}

/***** Id ile şube tanımı silme işlemi yapılır. *****/
function js_deleteDriverById(Id) {

	$.ajax({
		async: true,
		type: "POST",
		url: "/Driver/DeleteDriverById",
		data: { id: Id },
		success: function (data) {
			var result = data;
			mesajBox('mesaj', 'DURUM', result, 'success');
			$('#txtId').val(0);
			/*location.reload();*/

			var hrefSplit = location.href.split('/');
			var href = '';
			for (var i = 0; i < hrefSplit.length - 1; i++) {
				href += hrefSplit[i] + '/';
			}

			setTimeout(function () {
				if (href.indexOf("GetDriverByIdWithDetails") > 0) {
					location.replace(href.replace('GetDriverByIdWithDetails/', 'GetDriverByIdWithDetails/0'));
				}
				else {
					location.reload();
                }
				
			}, 200);

		},
		error: function (err) {
			mesajBox('mesaj', 'UYARI', err.responseText, 'warning');
		}
	});

}

function js_checkDriverForAdd(islem) {
	var imgDriver = $('#imgDriver').css('background-image');
	imgDriver = imgDriver.replace('url(', '').replace(')', '').replace(/\"/gi, "");

	if (imgDriver.indexOf('data') < 0) {
		imgDriver = null;
	}

	var id = $('#txtId').val();

	let driverInformation = {
		Id: $('#txtId').val(),
		SessionId: $('#selectSession option:selected').val(),
		Name: $('#txtName').val(),
		Surname: $('#txtSurname').val(),
		IdentityNo: $('#txtIdentityNo').val(),
		BranchId: $('#selectBranch option:selected').val(),
		CourseFee: $('#txtCourseFee').val(),
		CourseFeePlus: $('#txtCourseFeePlus').val(),
		Email: $('#txtEmail').val(),
		Phone1: $('#txtPhone1').val(),
		Phone2: $('#txtPhone2').val(),
		City: $('#txtCity').val(),
		County: $('#txtCounty').val(),
		Address1: $('#txtAddress1').val(),
		Address2: $('#txtAddress2').val(),
		Image: imgDriver,
		Note: $('#txtNote').val(),
		RecordDate: $('input[name="txtRecordDate"]').val(),
		IsCertificateDelivered: chkKontrol('chkIsCertificateDelivered'),
		CertificateDeliveredDate: $('input[name="txtCertificateDeliveredDate"]').val()
	};

	var saveState = true;
	if (id != 0) {

		saveState = js_checkDebitForCourseFeeAndCourseFeePlus(driverInformation);
		if (!saveState)
			return;

		saveState = js_checkPaymentPlantTotalAmounts(driverInformation,islem);
		if (!saveState)
			return;	

	}

	if (driverInformation.IsCertificateDelivered) {
		saveState = js_checkDebitForCertificate(driverInformation);
		if (!saveState)
			return;	

	}

	
	

	js_addDriver(islem);

}

/** Kullanıcı tanımı ekleme yada güncelleme işlemi yapılır. */
function js_addDriver(islem) {	

	var imgDriver = $('#imgDriver').css('background-image');
	imgDriver = imgDriver.replace('url(', '').replace(')', '').replace(/\"/gi, "");

	if (imgDriver.indexOf('data') < 0) {
		imgDriver = null;
	}

	var id = $('#txtId').val();

	let driverInformation = {
		Id: $('#txtId').val(),
		SessionId: $('#selectSession option:selected').val(),
		Name: $('#txtName').val(),
		Surname: $('#txtSurname').val(),
		IdentityNo: $('#txtIdentityNo').val(),
		BranchId: $('#selectBranch option:selected').val(),
		CourseFee: $('#txtCourseFee').val(),
		CourseFeePlus: $('#txtCourseFeePlus').val(),
		Email: $('#txtEmail').val(),
		Phone1: $('#txtPhone1').val(),
		Phone2: $('#txtPhone2').val(),
		City: $('#txtCity').val(),
		County: $('#txtCounty').val(),
		Address1: $('#txtAddress1').val(),
		Address2: $('#txtAddress2').val(),
		Image: imgDriver,
		Note: $('#txtNote').val(),
		RecordDate: $('input[name="txtRecordDate"]').val(),
		IsCertificateDelivered: chkKontrol('chkIsCertificateDelivered'),
		CertificateDeliveredDate: $('input[name="txtCertificateDeliveredDate"]').val()
	};


	$.ajax({
		async: true,
		type: "POST",
		url: "/Driver/AddDriver",
		data: driverInformation,
		success: function (data) {
			var result = data;
			mesajBox('mesaj', 'DURUM', 'Başarı ile Kaydedildi.', 'success');

			var hrefSplit = location.href.split('/');
			var href = '';
			for (var i = 0; i < hrefSplit.length - 1; i++) {
				href += hrefSplit[i] + '/';
			}

			setTimeout(function () {
				if (islem == 0) {
					location.replace(href.replace('GetDriverByIdWithDetails/', 'GetDriverByIdWithDetails/' + result));
				}
				else {
					location.replace(href.replace('GetDriverByIdWithDetails/', 'GetDriverByIdWithDetails/0'));
				}
			}, 200);


		},
		error: function (err) {
			mesajBox('mesaj', 'UYARI', err.responseText, 'warning');
		}
	});
}

function js_checkPaymentPlantTotalAmounts(driverInformation, islem) {

	var state = true;

	$.ajax({
		async: false,
		type: "POST",
		url: "/Driver/CheckPaymentPlanTotalAmounts",
		data: driverInformation,
		success: function (data) {
			var result = data;
			if (result != null && result!='')
			{				
				mesajBox_confirm('UYARI', 'UYARI', result, 'DEVAM ET', 'warning', 'js_addDriver(' + islem + ')');
				state = false;
				return state;
            }
			else {
				state = true;
				return state;
            }
		},
		error: function (err) {

			mesajBox('mesaj', 'UYARI', err.html, 'warning');
			state = true;
			return state;
		}
	});

	return state;
}

function js_checkDebitForCourseFeeAndCourseFeePlus(driverInformation) {
	var state = true;

	$.ajax({
		async: false,
		type: "POST",
		url: "/Driver/CheckDebitForCourseFeeAndCourseFeePlus",
		data: driverInformation,
		success: function (data) {
			var result = data;
			if (result != null && result != '') {
				mesajBox('mesaj', 'UYARI', result, 'warning');
				state = false;
				return state;
			}
			else {
				state = true;
				return state;
			}
		},
		error: function (err) {

			mesajBox('mesaj', 'UYARI', err.html, 'warning');
			state = true;
			return state;
		}
	});

	return state;
}

function js_checkDebitForCertificate(driverInformation) {
	var state = true;

	$.ajax({
		async: false,
		type: "POST",
		url: "/Driver/CheckDebitForCertificate",
		data: driverInformation,
		success: function (data) {
			var result = data;
			if (result != null && result != '') {
				mesajBox('mesaj', 'UYARI', result, 'warning');
				state = false;
				return state;
			}
			else {
				state = true;
				return state;
			}
		},
		error: function (err) {

			mesajBox('mesaj', 'UYARI', err.html, 'warning');
			state = true;
			return state;
		}
	});

	return state;
}


/***** Id ile Ödeme Planı getirilir *****/
function js_getDriverPaymentPlanById(Id,CollectionDefinitionType) {
	$('#dataDriverPaymentPlan').html("");

	var DriverId = $('#txtId').val();

	if (DriverId == null || DriverId <= 0) {

		$.ajax({
			async: true,
			type: "GET",
			url: "",
			contentType: "application/json; charset=utf-8",
			dataType: "html",
			success: function (data) {
				var result = data;
				$("#NewDriverPaymentPlan").modal('hide');
			},
			error: function (err) {
				$("#NewDriverPaymentPlan").modal('hide');

			}
		});

		mesajBox('mesaj', 'UYARI', 'Önce Sürücü Adayı Kaydedilmeli !', 'warning');
		$("#NewDriverPaymentPlan").modal('hide');
		return;
	}

	$.ajax({
		async: true,
		type: "GET",
		url: "/Driver/GetDriverPaymentPlanById",
		data: { id: Id, collectionDefinitionType: CollectionDefinitionType },
		contentType: "application/json; charset=utf-8",
		dataType: "html",
		success: function (data) {
			var result = data;

			$('#dataDriverPaymentPlan').html("");
			$('#dataDriverPaymentPlan').html(result);
		},
		error: function (err) {
			mesajBox('mesaj', 'UYARI', err.html, 'warning');
		}
	});

}

/** Silme işlemi öncesi kullanıcıya son ikaz yapılır */
function js_deleteDriverPaymentPlanByIdQ(Id, CollectionDefinitionType) {
	mesajBox_confirm('Sil', 'Sil', 'Tanımı Silmek İstediğinize Emin misiniz ?', 'Sil', 'danger', 'js_deleteDriverPaymentPlanById(' + Id + ', ' + CollectionDefinitionType + ')');
}

/***** Id ile Ödeme Planı silme işlemi yapılır. *****/
function js_deleteDriverPaymentPlanById(Id, CollectionDefinitionType) {

	$.ajax({
		async: true,
		type: "GET",
		url: "/Driver/DeleteDriverPaymentPlanById",
		data: { id: Id },
		contentType: "application/json; charset=utf-8",
		dataType: "html",
		success: function (data) {
			var result = data;
			if (CollectionDefinitionType == 10) {
				$('#dataListDriverPaymentPlan').html("");
				$('#dataListDriverPaymentPlan').html(result);
			}
			else {
				$('#dataListDriverPaymentPlusPlan').html("");
				$('#dataListDriverPaymentPlusPlan').html(result);
            }
						
		},
		error: function (err) {
			mesajBox('mesaj', 'UYARI', err.responseText, 'warning');
		}
	});

}

/** Ödeme Planı ekleme yada güncelleme işlemi yapılır. */
function js_addDriverPaymentPlan() {

	var CollectionDefinitionType = $('#txtCollectionDefinitionType').val();

	let driverPaymentPlan = {
		Id: $('#txtDriverPaymentPlanId').val(),
		PaymentDate: $('input[name="txtDriverPaymentPlanPaymentDate"]').val(),
		Amount: $('#txtDriverPaymentPlanAmount').val(),
		DriverInformationId: $('#txtId').val(),
		CollectionDefinitionType: $('#txtCollectionDefinitionType').val()
	};

	$.ajax({
		async: true,
		type: "POST",
		url: "/Driver/AddDriverPaymentPlan",
		data: driverPaymentPlan,
		success: function (data) {
			var result = data;

			if (CollectionDefinitionType == 10) {
				$('#dataListDriverPaymentPlan').html("");
				$('#dataListDriverPaymentPlan').html(result);
			}
			else {
				$('#dataListDriverPaymentPlusPlan').html("");
				$('#dataListDriverPaymentPlusPlan').html(result);
            }
			

			$("#NewDriverPaymentPlan").modal('hide');

		},
		error: function (err) {
			mesajBox('mesaj', 'UYARI', err.responseText, 'warning');
		}
	});
}

/** Ödeme Planı İçin Taksitlendirme Ekranı Açıyoruz**/
function js_newHirePurchase(CollectionDefinitionType) {
	var CourseFee = $('#txtCourseFee').val();
	var DriverId = $('#txtId').val();
	var CourseFeePlus = $('#txtCourseFeePlus').val();

	if (DriverId == null || DriverId <= 0) {

		$("#NewHirePurchase").modal('hide');

		mesajBox('mesaj', 'UYARI', 'Önce Sürücü Adayı Kaydedilmeli !', 'warning');
		return;
	}

	if (CollectionDefinitionType == 11) {
		CourseFee = CourseFeePlus;
    }

	if (CourseFee == null || parseInt(CourseFee, 2) <= 0) {

		$.ajax({
			async: true,
			type: "GET",
			url: "",
			contentType: "application/json; charset=utf-8",
			dataType: "html",
			success: function (data) {
				var result = data;
				$("#NewHirePurchase").modal('hide');
			},
			error: function (err) {
				$("#NewHirePurchase").modal('hide');

			}
		});
		if (CollectionDefinitionType == 10) {
			mesajBox('mesaj', 'UYARI', 'Kurs Ücreti Girilmemiş !', 'warning');
		}
		else {
			mesajBox('mesaj', 'UYARI', 'İlave 4 Hak Ücreti Girilmemiş !', 'warning');
        }
		
		$("#NewHirePurchase").modal('hide');
		return;
	}

	
	$.ajax({
		async: true,
		type: "POST",
		url: "/Driver/NewHirePurchase",
		data: { courseFee: CourseFee, collectionDefinitionType: CollectionDefinitionType },
		success: function (data) {
			var result = data;
			$('#dataHirePurchase').html("");
			$('#dataHirePurchase').html(result);
		},
		error: function (err) {
			mesajBox('mesaj', 'UYARI', err.responseText, 'warning');
		}
	});

}

function js_doHirePurchase() {
	var CollectionDefinitionType = $('#txtCollectionDefinitionType').val();
	var CourseFee = $('#txtCourseFee').val();
	var DriverId = $('#txtId').val();
	var CourseFeePlus = $('#txtCourseFeePlus').val();

	var HirePurchaseStartDate = $('input[name="txtHirePurchaseStartDate"]').val();
	if (HirePurchaseStartDate == null || HirePurchaseStartDate == 11) {
		mesajBox('mesaj', 'UYARI', 'Taksit Başlangıç Tarihi Boş Olamaz !', 'warning');
		return;
	}

	var HirePurchaseCount = $('#txtHirePurchaseCount').val();
	if (HirePurchaseCount == null || HirePurchaseCount <= 0) {
		mesajBox('mesaj', 'UYARI', 'Taksit Sayısı O dan Büyük Olmalıdır !', 'warning');
		return;
	}

	if (CollectionDefinitionType == 11) {
		CourseFee = CourseFeePlus;
    }

	$.ajax({
		async: true,
		type: "POST",
		url: "/Driver/AddDriverPaymentPlanWithHirePurchase",
		data: { driverId: DriverId, hirePurchaseStartDate: HirePurchaseStartDate, hirePurchaseCount: HirePurchaseCount, courseFee: CourseFee, collectionDefinitionType: CollectionDefinitionType },
		success: function (data) {
			var result = data;

			if (CollectionDefinitionType == 10) {
				$('#dataListDriverPaymentPlan').html("");
				$('#dataListDriverPaymentPlan').html(result);
			}
			else {
				$('#dataListDriverPaymentPlusPlan').html("");
				$('#dataListDriverPaymentPlusPlan').html(result);
            }
			

			$("#NewHirePurchase").modal('hide');

		},
		error: function (err) {
			mesajBox('mesaj', 'UYARI', err.responseText, 'warning');
		}
	});

}


/***** Id ile Ödeme Detayı tanımı getirilir *****/
function js_checkDriverCollectionDetail(IdList, Debit, Type, CollectionDefinitionId, CollectionDefinitionTypeId) {
	$('#dataDriverCollectionDetail').html("");

	if (IdList.split('/').length > 2) {
		$.ajax({
			async: true,
			type: "GET",
			url: "/Driver/GetCollectionDetailsByIdWithDetails",
			data: { idList: IdList, type: Type },
			contentType: "application/json; charset=utf-8",
			dataType: "html",
			success: function (data) {
				var result = data;
				$('#dataDriverCollectionDetailList').html("");
				$('#dataDriverCollectionDetailList').html(result);
				$('#CollectionDetailList').modal('show');
			},
			error: function (err) {
				
				mesajBox('mesaj', 'UYARI', err.html, 'warning');
			}
		});
		
	}
	else {
		
		$('#CollectionDetailList').modal('hide');

		if (Type == 'EditCollectionDetails') {			
			js_getDriverCollectionDetailByIdWithDetails(IdList.split('/')[0], Debit, CollectionDefinitionId, CollectionDefinitionTypeId);
		}
		else if (Type == 'PrintCollectionDetails') {
			js_printDriverCollectionDetail(IdList.split('/')[0])
		}
		else if (Type == 'DeleteCollectionDetails') {
			js_deleteDriverCollectionDetailByIdQ(IdList.split('/')[0]);
		}


	}



}

/***** Id ile Ödeme Detayı tanımı getirilir *****/
function js_getDriverCollectionDetailByIdWithDetails(Id, Debit, CollectionDefinitionId, CollectionDefinitionTypeId) {
	$('#dataDriverCollectionDetail').html("");

	$.ajax({
		async: true,
		type: "GET",
		url: "/Driver/GetCollectionDetailByIdWithDetails",
		data: { id: Id, debit: Debit, collectionDefinitionId: CollectionDefinitionId, collectionDefinitionTypeId: CollectionDefinitionTypeId },
		contentType: "application/json; charset=utf-8",
		dataType: "html",
		success: function (data) {
			var result = data;			
			$('#dataDriverCollectionDetail').html("");
			$('#dataDriverCollectionDetail').html(result);
			$('#NewDriverCollectionDetail').modal('show');
		},
		error: function (err) {
			mesajBox('mesaj', 'UYARI', err.html, 'warning');
		}
	});

}


/** Tahsilat Detayı ekleme yada güncelleme işlemi yapılır. */
function js_addEditDriverCollectionDetail() {

	let collectionDetail = {
		Id: $('#txtDriverCollectionDetailId').val(),
		PaymentTypeId: $('#selectPaymentType option:selected').val(),
		Amount: $('#txtDriverCollectionDetailAmount').val(),
		CollectionDefinitionId: $('#txtCollectionDefinitionId').val(),
		PaidBySelf: chkKontrol('chkPaidBySelf'),
		Hour: $('#txtHour').val()
	};

	var driverId = $('#txtId').val();
	var collectionId = $('#txtDriverCollectionId').val();

	$.ajax({
		async: true,
		type: "POST",
		url: "/Driver/AddEditDriverCollectionDetail",
		data: { collectionDetail: collectionDetail, driverId: driverId, collectionId: collectionId},
		success: function (data) {
			var result = data;

			var collectionDefinitionTypeId = $('#txtCollectionDefinitionTypeId').val();

			if (collectionDefinitionTypeId == 10) {
				$('#dataListDriverPaymentPlan').html("");
				$('#dataListDriverPaymentPlan').html(result);
			}
			else if (collectionDefinitionTypeId == 11) {
				$('#dataListDriverPaymentPlusPlan').html("");
				$('#dataListDriverPaymentPlusPlan').html(result);
			}
			else if (collectionDefinitionTypeId == 30) {
				$('#dataListDriverSequentialYSHPayment').html("");
				$('#dataListDriverSequentialYSHPayment').html(result);
			}
			else if (collectionDefinitionTypeId == 40) {
				$('#dataListDriverSequentialDSHFirstPayment').html("");
				$('#dataListDriverSequentialDSHFirstPayment').html(result);
			}
			else if (collectionDefinitionTypeId == 41) {
				$('#dataListDriverSequentialDSHPlusPayment').html("");
				$('#dataListDriverSequentialDSHPlusPayment').html(result);
			}
			else if (collectionDefinitionTypeId == 50) {
				$('#dataListDriverSequentialPrivateLesson').html("");
				$('#dataListDriverSequentialPrivateLesson').html(result);
			}			

			$("#NewDriverCollectionDetail").modal('hide');

		},
		error: function (err) {
			mesajBox('mesaj', 'UYARI', err.responseText, 'warning');
		}
	});


}

/** Silme işlemi öncesi kullanıcıya son ikaz yapılır */
function js_deleteDriverCollectionDetailByIdQ(Id) {
	if (Id > 0) {
		mesajBox_confirm('Sil', 'Sil', 'İlgili Tahsilatı Silmek İstediğinize Emin misiniz ?', 'Sil', 'danger', 'js_deleteDriverCollectionDetailById(' + Id + ')');
	}
}

/***** Id ile tahsilat detayı silme işlemi yapılır. *****/
function js_deleteDriverCollectionDetailById(Id) {

	$('#CollectionDetailList').modal('hide');

	$.ajax({
		async: true,
		type: "POST",
		url: "/Driver/DeleteDriverCollectionDetailById",
		data: { id: Id },
		success: function (data) {
			var result = data;
			mesajBox('mesaj', 'DURUM', 'Başarı İle Silindi.', 'success');
			location.reload();
		},
		error: function (err) {
			if (err.responseText.indexOf('FK_') > -1)
				mesajBox('mesaj', 'UYARI', 'Bu Tanım Kullanılıyor !', 'warning');
			else
				mesajBox('mesaj', 'UYARI', err.responseText, 'danger');
		}
	});

}

/***** Id ile tahsilat detayı yazdırma işlemi yapılır. *****/
function js_printDriverCollectionDetail(Id) {


	$.ajax({
		async: true,
		type: "POST",
		url: "/Driver/PrintDriverCollectionDetail",
		data: { id: Id },
		success: function (data) {
			var result = data;
			$('#NewDriverCollectionDetail').modal('hide');
			js_print(result, 'As Gözde Tahsilat Makbuzu');
		},
		error: function (err) {
			mesajBox('mesaj', 'UYARI', err.html, 'warning');
		}
	});
}


/***** Sürücü Adayının Adres Beyan Formu Yazdırılır *****/
function js_printAddressForm() {

	var DriverId = $('#txtId').val();
	if (DriverId == null || DriverId <= 0) {

		mesajBox('mesaj', 'UYARI', 'Önce Sürücü Adayı Kaydedilmeli !', 'warning');
		return;
	}

	$.ajax({
		async: true,
		type: "POST",
		url: "/Driver/PrintAddressForm",
		data: { id: DriverId },
		success: function (data) {
			var result = data;
			js_print(result, 'As Gözde Adres Beyan Formu');
		},
		error: function (err) {
			mesajBox('mesaj', 'UYARI', err.html, 'warning');
		}
	});
}


/***** Sürücü Adayının Müracaat Formu Yazdırılır *****/
function js_printApplicationForm() {

	var DriverId = $('#txtId').val();
	if (DriverId == null || DriverId <= 0) {

		mesajBox('mesaj', 'UYARI', 'Önce Sürücü Adayı Kaydedilmeli !', 'warning');
		return;
	}

	$.ajax({
		async: true,
		type: "POST",
		url: "/Driver/PrintApplicationForm",
		data: { id: DriverId },
		success: function (data) {
			var result = data;
			js_print(result, 'As Gözde Müracaat Formu');
		},
		error: function (err) {
			mesajBox('mesaj', 'UYARI', err.html, 'warning');
		}
	});
}

function js_getAllCollectionDetailsByDriverInformationId(Id) {
    if (Id==null || Id<=0) {	

		mesajBox('mesaj', 'UYARI', 'Önce Sürücü Adayı Kaydedilmeli !', 'warning');
		return;	
	}

	$.ajax({
		async: true,
		type: "GET",
		url: "/Driver/GetAllCollectionDetailsByDriverInformationId",
		data: { driverId: Id },
		contentType: "application/json; charset=utf-8",
		dataType: "html",
		success: function (data) {
			var result = data;
			$('#dataCollectionDetailListOfDriver').html("");
			$('#dataCollectionDetailListOfDriver').html(result);
			$('#CollectionDetailListOfDriver').modal('show');
		},
		error: function (err) {
			mesajBox('mesaj', 'UYARI', err.html, 'warning');
		}
	});
}

///***** Sürücü Adayı K sınıfı Sürücü Aday Belgesi Yazdırılır *****/
//function js_printKFile(Id) {
//	$.ajax({
//		async: true,
//		type: "GET",
//		url: "/Report/KFileReport",
//		data: { driverInformationId: Id },
//		contentType: "application/json; charset=utf-8",
//		success: function (data) {
//			var result = data;
//			//$('#dataDriver').html("");
//			//$('#dataDriver').html(result);
//		},
//		error: function (err) {
//			mesajBox('mesaj', 'UYARI', err.responseText, 'warning');
//		}
//	});

//}









