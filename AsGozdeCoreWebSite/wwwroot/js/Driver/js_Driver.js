const { Alert } = require("bootstrap");

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
	mesajBox_confirm('Sil', 'Sil', 'Tanımı Silmek İstediğinize Emin misiniz ?', 'Sil', 'danger', 'js_deleteDriverById(' + Id + ')');
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
function js_addDriver() {

	let Driver = {
		DriverId: $('#txtDriverId').val(),
		DriverName: $('#txtDriverName').val(),
		FirstName: $('#txtFirstName').val(),
		LastName: $('#txtLastName').val(),
		Title: $('#txtUnvan').val(),
		Active: chkKontrol('chkActive'),
		OfficeId: $('#selectOffice option:selected').val()
	};

	if (Driver.DriverName != null && Driver.DriverName != "") {
		$.ajax({
			async: true,
			type: "POST",
			url: "/Driver/AddDriver",
			data: Driver,
			success: function (data) {
				var result = data;
				mesajBox('mesaj', 'DURUM', result, 'success');
				location.reload();
			},
			error: function (err) {
				mesajBox('mesaj', 'UYARI', err.responseText, 'warning');
			}
		});
	}
	else
		mesajBox('mesaj', 'UYARI', 'Kullanıcı Kodu Boş Olamaz !', 'warning');


}

