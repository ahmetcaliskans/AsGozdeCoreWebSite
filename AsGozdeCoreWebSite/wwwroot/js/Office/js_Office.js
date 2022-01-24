const { Alert } = require("bootstrap");

/***** Id ile şube tanımı getirilir *****/
function js_getOfficeById(Id) {
	$('#dataOffice').html("");

	$.ajax({
		async: true,
		type: "GET",
		url: "/Office/GetOfficeById",
		data: {id:Id},
		contentType: "application/json; charset=utf-8",
		dataType: "html",
		success: function (data) {
			var result = data;
			$('#dataOffice').html("");
			$('#dataOffice').html(result);
		},
		error: function (err) {
			mesajBox('mesaj', 'UYARI', err.html, 'warning');
        }
	});

}

/** Silme işlemi öncesi kullanıcıya son ikaz yapılır */
function js_deleteOfficeByIdQ(Id) {
	mesajBox_confirm('Sil', 'Sil', 'Tanımı Silmek İstediğinize Emin misiniz ?', 'Sil', 'danger', 'js_deleteOfficeById(' + Id + ')');
}

/***** Id ile şube tanımı silme işlemi yapılır. *****/
function js_deleteOfficeById(Id) {

	$.ajax({
		async: true,
		type: "POST",
		url: "/Office/DeleteOfficeById",
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

/** Şube tanımı ekleme yada güncelleme işlemi yapılır. */
function js_addOffice() {

	let office = {
		Id: $('#txtId').val(),
		Name: $('#txtName').val(),
		Description: $('#txtDescription').val()
	};

	if (office.Name != null && office.Name!="") {
		$.ajax({
			async: true,
			type: "POST",
			url: "/Office/AddOffice",
			data: office,
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
		mesajBox('mesaj', 'UYARI', 'Şube Adı Boş Olamaz !', 'warning');

	
}

