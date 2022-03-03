

/***** Id ile Tahsilat tanımı getirilir *****/
function js_getCollectionByIdWithDetails(Id) {
	$.ajax({
		async: true,
		type: "GET",
		url: "/Collection/GetCollectionByIdWithDetails",
		data: { id: Id },
		contentType: "application/json; charset=utf-8",
		dataType: "html",
		success: function (data) {
			var result = data;
		},
		error: function (err) {
			mesajBox('mesaj', 'UYARI', err.html, 'warning');
		}
	});

}

/** Silme işlemi öncesi kullanıcıya son ikaz yapılır */
function js_deleteCollectionByIdQ(Id) {
    if (Id>0) {
		mesajBox_confirm('Sil', 'Sil', 'Tanımı Silmek İstediğinize Emin misiniz ?', 'Sil', 'danger', 'js_deleteCollectionById(' + Id + ')');
    }
	
}

/***** Id ile Tahsilat silme işlemi yapılır. *****/
function js_deleteCollectionById(Id) {

	$.ajax({
		async: true,
		type: "POST",
		url: "/Collection/DeleteCollectionById",
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

/** Tahsilat ekleme yada güncelleme işlemi yapılır. */
function js_addCollection(islem) {	

	var driverNameSurname = $('#txtDriverNameSurname').val();
	if (driverNameSurname == null || driverNameSurname=="") {
		mesajBox('mesaj', 'UYARI', 'Lütfen Sürücü Adayı Seçiniz !', 'warning');
		return;
	}

	var collectionDate = $('input[name="txtCollectionDate"]').val();
	if (collectionDate == null || collectionDate == "") {
		mesajBox('mesaj', 'UYARI', 'Lütfen Bir Tarih Seçiniz !', 'warning');
		return;
	}


	var CollectionDetailCount = $('#kt_datatable tbody tr').length;
	if (CollectionDetailCount == null || CollectionDetailCount == 0) {
		mesajBox('mesaj', 'UYARI', 'Lütfen Tahsilat İşlemi Giriniz !', 'warning');
		return;
	}
			

	$.ajax({
		async: true,
		type: "POST",
		url: "/Collection/AddCollection",
		data: { collectionDate: collectionDate },
		success: function (data) {
			var result = data;
			mesajBox('mesaj', 'DURUM', result[0], 'success');

			var hrefSplit = location.href.split('/');
			var href = '';
			for (var i = 0; i < hrefSplit.length - 1; i++) {
				href += hrefSplit[i] + '/';
			}

			setTimeout(function () {
				if (islem == 0) {
					location.replace(href.replace('GetCollectionByIdWithDetails/', 'GetCollectionByIdWithDetails/' + result[1]));
				}
				else {
					location.replace(href.replace('GetCollectionByIdWithDetails/', 'GetCollectionByIdWithDetails/0'));
				}
			}, 200);
			
			
		},
		error: function (err) {
			mesajBox('mesaj', 'UYARI', err.responseText, 'warning');
		}
	});


}




/***** Id ile şube tanımı getirilir *****/
function js_getCollectionDetailByIdWithDetails(Id) {
	$('#dataCollectionDetail').html("");

	$.ajax({
		async: true,
		type: "GET",
		url: "/Collection/GetCollectionDetailByIdWithDetails",
		data: { id: Id },
		contentType: "application/json; charset=utf-8",
		dataType: "html",
		success: function (data) {
			var result = data;
			$('#dataCollectionDetail').html("");
			$('#dataCollectionDetail').html(result);
		},
		error: function (err) {
			mesajBox('mesaj', 'UYARI', err.html, 'warning');
		}
	});

}

/** Silme işlemi öncesi kullanıcıya son ikaz yapılır */
function js_deleteCollectionDetailByIdQ(Id) {
	mesajBox_confirm('Sil', 'Sil', 'Tanımı Silmek İstediğinize Emin misiniz ?', 'Sil', 'danger', 'js_deleteCollectionDetailById(' + Id + ')');
}

/***** Id ile Tahsilat Detayı silme işlemi yapılır. *****/
function js_deleteCollectionDetailById(Id) {

	$.ajax({
		async: true,
		type: "GET",
		url: "/Collection/DeleteCollectionDetailById",
		data: { id: Id },
		contentType: "application/json; charset=utf-8",
		dataType: "html",
		success: function (data) {
			var result = data;
			$('#dataListCollectionDetail').html("");
			$('#dataListCollectionDetail').html(result);
		},
		error: function (err) {
			if (err.responseText.indexOf('FK_') > -1)
				mesajBox('mesaj', 'UYARI', 'Bu Tanım Kullanılıyor !', 'warning');
			else
				mesajBox('mesaj', 'UYARI', err.responseText, 'danger');
		}
	});

}

/** Tahsilat Detayı ekleme yada güncelleme işlemi yapılır. */
function js_addCollectionDetail() {

	let collectionDetail = {
		Id: $('#txtId').val(),
		PaymentTypeId: $('#selectPaymentType option:selected').val(),
		CollectionDefinitionId: $('#selectCollectionDefinition option:selected').val(),
		Amount: $('#txtAmount').val()
	};

	$.ajax({
		async: true,
		type: "POST",
		url: "/Collection/AddCollectionDetail",
		data: collectionDetail,
		success: function (data) {
			var result = data;
			$('#dataListCollectionDetail').html("");
			$('#dataListCollectionDetail').html(result);

			$("#NewCollectionDetail").modal('hide');			
			
		},
		error: function (err) {
			mesajBox('mesaj', 'UYARI', err.responseText, 'warning');
		}
	});


}




/***** Id ile şube tanımı getirilir *****/
function js_getDriverInformationsWithDetails() {
	$('#dataDriverInformations').html("");

	$.ajax({
		async: true,
		type: "GET",
		url: "/Collection/GetDriverInformationsWithDetails",
		contentType: "application/json; charset=utf-8",
		dataType: "html",
		success: function (data) {
			var result = data;
			$('#dataDriverInformations').html("");
			$('#dataDriverInformations').html(result);
		},
		error: function (err) {
			mesajBox('mesaj', 'UYARI', err.html, 'warning');
		}
	});
}

/***** Seçili Sürücü Adayını İlgili Ekrana Ekliyoruz *****/
function js_addDriverById(Id) {

	$.ajax({
		async: true,
		type: "GET",
		url: "/Collection/GetDriverInformationByIdWithDetails",
		data: { id: Id },
		contentType: "application/json; charset=utf-8",
		dataType: "html",
		success: function (data) {
			var result = data;			
			$('#dataDriverInformation').html("");
			$('#dataDriverInformation').html(result);
			
		},
		error: function (err) {
			mesajBox('mesaj', 'UYARI', err.html, 'warning');
		}
	});

	$("#NewDriverInformation").modal('hide');
}

function js_printCollection(Id) {

	$.ajax({
		async: true,
		type: "POST",
		url: "/Collection/PrintCollection",
		data: { id: Id },
		success: function (data) {
			var result = data;
			js_print(result, 'As Gözde Tahsilat Makbuzu');
		},
		error: function (err) {
			mesajBox('mesaj', 'UYARI', err.html, 'warning');
		}
	});
}

function js_print(data,baslik) {

	var mywindow = window.open('', baslik, 'height=900,width=1200');
	mywindow.document.write(data);

	mywindow.document.close(); // necessary for IE >= 10
	mywindow.focus(); // necessary for IE >= 10

	mywindow.resizeTo(screen.width, screen.height);
	setTimeout(function () {
		mywindow.print();
		mywindow.close();
	}, 100);


	return true;

}

