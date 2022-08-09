const { Alert } = require("bootstrap");

/***** Id ile demirbaş tanımları tanımı getirilir *****/
function js_getFixtureDefinitionById(Id) {
	$('#dataFixtureDefinition').html("");

	$.ajax({
		async: true,
		type: "GET",
		url: "/FixtureDefinition/GetFixtureDefinitionById",
		data: { id: Id },
		contentType: "application/json; charset=utf-8",
		dataType: "html",
		success: function (data) {
			var result = data;
			$('#dataFixtureDefinition').html("");
			$('#dataFixtureDefinition').html(result);
		},
		error: function (err) {
			mesajBox('mesaj', 'UYARI', err.html, 'warning');
		}
	});

}

/** Silme işlemi öncesi kullanıcıya son ikaz yapılır */
function js_deleteFixtureDefinitionByIdQ(Id) {
	mesajBox_confirm('Sil', 'Sil', 'Tanımı Silmek İstediğinize Emin misiniz ?', 'Sil', 'danger', 'js_deleteFixtureDefinitionById(' + Id + ')');
}

/***** Id ile demirbaş tanımları tanımı silme işlemi yapılır. *****/
function js_deleteFixtureDefinitionById(Id) {

	$.ajax({
		async: true,
		type: "POST",
		url: "/FixtureDefinition/DeleteFixtureDefinitionById",
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

/** demirbaş tanımları tanımı ekleme yada güncelleme işlemi yapılır. */
function js_addFixtureDefinition() {

	let FixtureDefinition = {
		Id: $('#txtId').val(),
		Name: $('#txtName').val(),
		Description: $('#txtDescription').val(),
		Year: $('#txtYear').val(),
		Note: $('#txtNote').val(),
		Active: chkKontrol('chkActive')

	};

	$.ajax({
		async: true,
		type: "POST",
		url: "/FixtureDefinition/AddFixtureDefinition",
		data: FixtureDefinition,
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

