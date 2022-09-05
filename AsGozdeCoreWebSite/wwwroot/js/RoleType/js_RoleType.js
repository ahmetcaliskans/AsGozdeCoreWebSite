const { Alert } = require("bootstrap");

/***** Id ile şube tanımı getirilir *****/
function js_getRoleTypeById(Id) {
	$('#dataRoleType').html("");

	$.ajax({
		async: true,
		type: "GET",
		url: "/RoleType/GetRoleTypeById",
		data: { id: Id },
		contentType: "application/json; charset=utf-8",
		dataType: "html",
		success: function (data) {
			var result = data;
			$('#dataRoleType').html("");
			$('#dataRoleType').html(result);
		},
		error: function (err) {
			mesajBox('mesaj', 'UYARI', err.html, 'warning');
		}
	});

}

/** Silme işlemi öncesi kullanıcıya son ikaz yapılır */
function js_deleteRoleTypeByIdQ(Id) {
	mesajBox_confirm('Sil', 'Sil', 'Tanımı Silmek İstediğinize Emin misiniz ?', 'Sil', 'danger', 'js_deleteRoleTypeById(' + Id + ')');
}

/***** Id ile şube tanımı silme işlemi yapılır. *****/
function js_deleteRoleTypeById(Id) {

	$.ajax({
		async: true,
		type: "POST",
		url: "/RoleType/DeleteRoleTypeById",
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
function js_addRoleType() {

	let RoleType = {
		Id: $('#txtId').val(),
		Name: $('#txtName').val(),
		Description: $('#txtDescription').val()
	};

	$.ajax({
		async: true,
		type: "POST",
		url: "/RoleType/AddRoleType",
		data: RoleType,
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

