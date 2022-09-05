const { Alert } = require("bootstrap");

/***** Id ile şube tanımı getirilir *****/
function js_getRoleFormDefinitionById(Id) {
	$('#dataRoleFormDefinition').html("");

	$.ajax({
		async: true,
		type: "GET",
		url: "/RoleFormDefinition/GetRoleFormDefinitionById",
		data: { id: Id },
		contentType: "application/json; charset=utf-8",
		dataType: "html",
		success: function (data) {
			var result = data;
			$('#dataRoleFormDefinition').html("");
			$('#dataRoleFormDefinition').html(result);
		},
		error: function (err) {
			mesajBox('mesaj', 'UYARI', err.html, 'warning');
		}
	});

}

/** Silme işlemi öncesi kullanıcıya son ikaz yapılır */
function js_deleteRoleFormDefinitionByIdQ(Id) {
	mesajBox_confirm('Sil', 'Sil', 'Tanımı Silmek İstediğinize Emin misiniz ?', 'Sil', 'danger', 'js_deleteRoleFormDefinitionById(' + Id + ')');
}

/***** Id ile şube tanımı silme işlemi yapılır. *****/
function js_deleteRoleFormDefinitionById(Id) {

	$.ajax({
		async: true,
		type: "POST",
		url: "/RoleFormDefinition/DeleteRoleFormDefinitionById",
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
function js_addRoleFormDefinition() {

	let RoleFormDefinition = {
		Id: $('#txtId').val(),
		FormName: $('#txtFormName').val(),
		FormSubName: $('#txtFormSubName').val(),
		Description: $('#txtDescription').val(),
		SpecialRole1Description: $('#txtSpecialRole1Description').val(),
		SpecialRole2Description: $('#txtSpecialRole2Description').val(),
		SpecialRole3Description: $('#txtSpecialRole3Description').val(),
		SpecialRole4Description: $('#txtSpecialRole4Description').val(),
		SpecialRole5Description: $('#txtSpecialRole5Description').val()
	};

	$.ajax({
		async: true,
		type: "POST",
		url: "/RoleFormDefinition/AddRoleFormDefinition",
		data: RoleFormDefinition,
		success: function (data) {
			var result = data;
			mesajBox('mesaj', 'DURUM', result, 'success');
			location.reload();
		},
		error: function (err) {
			mesajBox('mesaj', 'UYARI', messageParse(err.responseText), 'warning');
		}
	});


}

