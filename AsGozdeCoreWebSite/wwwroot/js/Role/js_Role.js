const { Alert } = require("bootstrap");

/***** Id ile şube tanımı getirilir *****/
function js_getRoleByRoleTypeIdAndRoleFormDefinitionId(roleTypeId,roleFormDefinitionId) {
	$('#dataRole').html("");

	$.ajax({
		async: true,
		type: "GET",
		url: "/Role/GetRoleByRoleTypeIdAndRoleFormDefinitionId",
		data: { roleTypeId: roleTypeId, roleFormDefinitionId: roleFormDefinitionId },
		contentType: "application/json; charset=utf-8",
		dataType: "html",
		success: function (data) {
			var result = data;
			$('#dataRole').html("");
			$('#dataRole').html(result);
		},
		error: function (err) {
			mesajBox('mesaj', 'UYARI', err.html, 'warning');
		}
	});

}

/** Silme işlemi öncesi kullanıcıya son ikaz yapılır */
function js_deleteRoleByIdQ(Id) {
	mesajBox_confirm('Sil', 'Sil', 'Tanımı Silmek İstediğinize Emin misiniz ?', 'Sil', 'danger', 'js_deleteRoleById(' + Id + ')');
}

/***** Id ile şube tanımı silme işlemi yapılır. *****/
function js_deleteRoleById(Id) {

    if (Id>0) {
		$.ajax({
			async: true,
			type: "POST",
			url: "/Role/DeleteRoleById",
			data: { id: Id },
			success: function (data) {
				var result = data;
				//mesajBox('mesaj', 'DURUM', result, 'success');
				//location.reload();				
				js_search_datatableAjax_Role();
			},
			error: function (err) {
				if (err.responseText.indexOf('FK_') > -1)
					mesajBox('mesaj', 'UYARI', 'Bu Tanım Kullanılıyor !', 'warning');
				else
					mesajBox('mesaj', 'UYARI', err.responseText, 'danger');
			}
		});
    }
	

}

/** Şube tanımı ekleme yada güncelleme işlemi yapılır. */
function js_addRole() {

	let Role = {
		Id: $('#txtId').val(),
		RoleTypeId: $('#txtRoleTypeId').val(),
		RoleFormDefinitionId: $('#txtRoleFormDefinitionId').val(),
		Show: chkKontrol('chkShow'),
		Insert: chkKontrol('chkInsert'),
		Update: chkKontrol('chkUpdate'),
		Delete: chkKontrol('chkDelete'),
		Print: chkKontrol('chkPrint'),
		Export: chkKontrol('chkExport'),
		SpecialRole1: chkKontrol('chkSpecialRole1'),
		SpecialRole2: chkKontrol('chkSpecialRole2'),
		SpecialRole3: chkKontrol('chkSpecialRole3'),
		SpecialRole4: chkKontrol('chkSpecialRole4'),
		SpecialRole5: chkKontrol('chkSpecialRole5')
	};

	$.ajax({
		async: true,
		type: "POST",
		url: "/Role/AddRole",
		data: Role,
		success: function (data) {
			var result = data;
			//mesajBox('mesaj', 'DURUM', result, 'success');
			//location.reload();
			//$("#NewRole").modal('hide');
			js_search_datatableAjax_Role();
		},
		error: function (err) {
			mesajBox('mesaj', 'UYARI', messageParse(err.responseText), 'warning');
		}
	});


}

function js_search_datatableAjax_Role() {
	var datatableAjax_Role = $('#datatableAjax_Role').KTDatatable();
	datatableAjax_Role.destroy();
	KTDatatableRemoteAjaxRoles.init();
};

