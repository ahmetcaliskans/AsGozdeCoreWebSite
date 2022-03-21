const { Alert } = require("bootstrap");

/***** Id ile tahsilat tanımları tanımı getirilir *****/
function js_getCollectionDefinitionById(Id) {
	$('#dataCollectionDefinition').html("");

	$.ajax({
		async: true,
		type: "GET",
		url: "/CollectionDefinition/GetCollectionDefinitionById",
		data: { id: Id },
		contentType: "application/json; charset=utf-8",
		dataType: "html",
		success: function (data) {
			var result = data;
			$('#dataCollectionDefinition').html("");
			$('#dataCollectionDefinition').html(result);
		},
		error: function (err) {
			mesajBox('mesaj', 'UYARI', err.html, 'warning');
		}
	});

}

/** Silme işlemi öncesi kullanıcıya son ikaz yapılır */
function js_deleteCollectionDefinitionByIdQ(Id) {
	mesajBox_confirm('Sil', 'Sil', 'Tanımı Silmek İstediğinize Emin misiniz ?', 'Sil', 'danger', 'js_deleteCollectionDefinitionById(' + Id + ')');
}

/***** Id ile tahsilat tanımları tanımı silme işlemi yapılır. *****/
function js_deleteCollectionDefinitionById(Id) {

	$.ajax({
		async: true,
		type: "POST",
		url: "/CollectionDefinition/DeleteCollectionDefinitionById",
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

/** tahsilat tanımları tanımı ekleme yada güncelleme işlemi yapılır. */
function js_addCollectionDefinition() {

	let CollectionDefinition = {
		Id: $('#txtId').val(),
		Name: $('#txtName').val(),
		Description: $('#txtDescription').val(),
		Sequence: $('#txtSequence').val(),
		IsSequence: chkKontrol('chkIsSequence'),
		IsPrivateLesson: chkKontrol('chkIsPrivateLesson'),
		PayBySelf: chkKontrol('chkPayBySelf'),
		Active: chkKontrol('chkActive')
	};

	$.ajax({
		async: true,
		type: "POST",
		url: "/CollectionDefinition/AddCollectionDefinition",
		data: CollectionDefinition,
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

