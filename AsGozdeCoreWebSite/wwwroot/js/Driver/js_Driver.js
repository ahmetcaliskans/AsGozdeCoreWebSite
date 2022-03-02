

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
		Address2: $('#txtAddress2').val()
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

