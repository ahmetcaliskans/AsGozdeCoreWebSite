const { Alert } = require("bootstrap");

/***** Id ile şube tanımı getirilir *****/
function js_getSessionById(Id) {
	$('#dataSession').html("");

	$.ajax({
		async: true,
		type: "GET",
		url: "/Session/GetSessionById",
		data: { id: Id },
		contentType: "application/json; charset=utf-8",
		dataType: "html",
		success: function (data) {
			var result = data;
			$('#dataSession').html("");
			$('#dataSession').html(result);
		},
		error: function (err) {
			mesajBox('mesaj', 'UYARI', err.html, 'warning');
		}
	});

}

/** Silme işlemi öncesi kullanıcıya son ikaz yapılır */
function js_deleteSessionByIdQ(Id) {
	mesajBox_confirm('Sil', 'Sil', 'Tanımı Silmek İstediğinize Emin misiniz ?', 'Sil', 'danger', 'js_deleteSessionById(' + Id + ')');
}

/***** Id ile şube tanımı silme işlemi yapılır. *****/
function js_deleteSessionById(Id) {

	$.ajax({
		async: true,
		type: "POST",
		url: "/Session/DeleteSessionById",
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
function js_addSession() {

	let Session = {
		Id: $('#txtId').val(),
		Name: $('#txtName').val(),
		Description: $('#txtDescription').val(),
		Year: $('#txtYear').val(),
		Sequence: $('#txtSequence').val(),
		Active: chkKontrol('chkActive')
	};

	$.ajax({
		async: true,
		type: "POST",
		url: "/Session/AddSession",
		data: Session,
		success: function (data) {
			var result = data;
			mesajBox('mesaj', 'DURUM', result, 'success');
			location.reload();
		},
		error: function (err) {
			mesajBox('mesaj', 'UYARI', fluentValidationMessageParse(err.responseText), 'warning');
		}
	});


}

