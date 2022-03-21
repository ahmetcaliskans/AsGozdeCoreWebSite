'use strict';

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
			mesajBox('mesaj', 'UYARI', err.html, 'warning');
		}
	});
}

/** Silme işlemi öncesi kullanıcıya son ikaz yapılır */
function js_deleteDriverByIdQ(Id) {
    if (Id>0) {
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
		Email: $('#txtEmail').val(),
		Phone1: $('#txtPhone1').val(),
		Phone2: $('#txtPhone2').val(),
		City: $('#txtCity').val(),
		County: $('#txtCounty').val(),
		Address1: $('#txtAddress1').val(),
		Address2: $('#txtAddress2').val(),
		Image: imgDriver
	};	


	if (driverInformation.Name == null || driverInformation.Name == "") {
		mesajBox('mesaj', 'UYARI', 'Sürücü Adayı Adı Alanı Boş Olamaz !', 'warning');
		return;
	}

	if (driverInformation.Surname == null || driverInformation.Surname == "") {
		mesajBox('mesaj', 'UYARI', 'Sürücü Adayı Soyadı Alanı Boş Olamaz !', 'warning');
		return;
	}		

	$.ajax({
		async: true,
		type: "POST",
		url: "/Driver/AddDriver",
		data: driverInformation,
		success: function (data) {
			var result = data;
			mesajBox('mesaj', 'DURUM', result, 'success');

			var hrefSplit = location.href.split('/');
			var href = '';
			for (var i = 0; i < hrefSplit.length - 1; i++) {
				href += hrefSplit[i] + '/';
			}

			setTimeout(function () {
				if (islem == 0) {					
					location.replace(href.replace('GetDriverByIdWithDetails/', 'Index'));
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


/***** Id ile Ödeme Planı getirilir *****/
function js_getDriverPaymentPlanById(Id) {
	$('#dataDriverPaymentPlan').html("");

	$.ajax({
		async: true,
		type: "GET",
		url: "/Driver/GetDriverPaymentPlanById",
		data: { id: Id },
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
function js_deleteDriverPaymentPlanByIdQ(Id) {
	mesajBox_confirm('Sil', 'Sil', 'Tanımı Silmek İstediğinize Emin misiniz ?', 'Sil', 'danger', 'js_deleteDriverPaymentPlanById(' + Id + ')');
}

/***** Id ile Ödeme Planı silme işlemi yapılır. *****/
function js_deleteDriverPaymentPlanById(Id) {

	$.ajax({
		async: true,
		type: "GET",
		url: "/Driver/DeleteDriverPaymentPlanById",
		data: { id: Id },
		contentType: "application/json; charset=utf-8",
		dataType: "html",
		success: function (data) {
			var result = data;
			$('#dataListDriverPaymentPlan').html("");
			$('#dataListDriverPaymentPlan').html(result);
		},
		error: function (err) {
			if (err.responseText.indexOf('FK_') > -1)
				mesajBox('mesaj', 'UYARI', 'Bu Tanım Kullanılıyor !', 'warning');
			else
				mesajBox('mesaj', 'UYARI', err.responseText, 'danger');
		}
	});

}

/** Ödeme Planı ekleme yada güncelleme işlemi yapılır. */
function js_addDriverPaymentPlan() {

	let driverPaymentPlan = {
		Id: $('#txtDriverPaymentPlanId').val(),
		PaymentDate: $('input[name="txtDriverPaymentPlanPaymentDate"]').val(),
		Amount: $('#txtDriverPaymentPlanAmount').val()
	};

	$.ajax({
		async: true,
		type: "POST",
		url: "/Driver/AddDriverPaymentPlan",
		data: driverPaymentPlan,
		success: function (data) {
			var result = data;
			$('#dataListDriverPaymentPlan').html("");
			$('#dataListDriverPaymentPlan').html(result);

			$("#NewDriverPaymentPlan").modal('hide');

		},
		error: function (err) {
			mesajBox('mesaj', 'UYARI', err.responseText, 'warning');
		}
	});
}

/** Ödeme Planı İçin Taksitlendirme Ekranı Açıyoruz**/
function js_newHirePurchase() {
	var CourseFee = $('#txtCourseFee').val();

	if (CourseFee == null || parseInt(CourseFee,2) <= 0) {		
		mesajBox('mesaj', 'UYARI', 'Kurs Ücreti Girilmemiş !', 'warning');
		$("#NewHirePurchase").modal('hide');
		return;
	}

	$.ajax({
		async: true,
		type: "POST",
		url: "/Driver/NewHirePurchase",
		data: { courseFee: CourseFee },
		success: function (data) {
			var result = data;
			$('#dataHirePurchase').html("");
			$('#dataHirePurchase').html(result);
		},
		error: function (err) {
			mesajBox('mesaj', 'UYARI', err.html, 'warning');
		}
	});

}

function js_doHirePurchase() {

	var CourseFee = $('#txtCourseFee').val();

	var HirePurchaseStartDate = $('input[name="txtHirePurchaseStartDate"]').val();
	if (HirePurchaseStartDate == null || HirePurchaseStartDate==11) {
		mesajBox('mesaj', 'UYARI', 'Taksit Başlangıç Tarihi Boş Olamaz !', 'warning');
		return;
    }

	var HirePurchaseCount = $('#txtHirePurchaseCount').val();
	if (HirePurchaseCount == null || HirePurchaseCount<=0) {
		mesajBox('mesaj', 'UYARI', 'Taksit Sayısı O dan Büyük Olmalıdır !', 'warning');
		return;
    }

	$.ajax({
		async: true,
		type: "POST",
		url: "/Driver/AddDriverPaymentPlanWithHirePurchase",
		data: { hirePurchaseStartDate: HirePurchaseStartDate, hirePurchaseCount: HirePurchaseCount, courseFee: CourseFee },
		success: function (data) {
			var result = data;
			$('#dataListDriverPaymentPlan').html("");
			$('#dataListDriverPaymentPlan').html(result);

			$("#NewHirePurchase").modal('hide');

		},
		error: function (err) {
			mesajBox('mesaj', 'UYARI', err.responseText, 'warning');
		}
	});
	
}






