const { Alert } = require("bootstrap");

/***** Id ile şube tanımı getirilir *****/
function js_getUserById(Id) {
	$('#dataUser').html("");

	$.ajax({
		async: true,
		type: "GET",
		url: "/User/GetUserById",
		data: { id: Id },
		contentType: "application/json; charset=utf-8",
		dataType: "html",
		success: function (data) {
			var result = data;
			$('#dataUser').html("");
			$('#dataUser').html(result);
		},
		error: function (err) {
			mesajBox('mesaj', 'UYARI', err.html, 'warning');
		}
	});

}

/** Silme işlemi öncesi kullanıcıya son ikaz yapılır */
function js_deleteUserByIdQ(Id) {
	mesajBox_confirm('Sil', 'Sil', 'Tanımı Silmek İstediğinize Emin misiniz ?', 'Sil', 'danger', 'js_deleteUserById(' + Id + ')');
}

/***** Id ile şube tanımı silme işlemi yapılır. *****/
function js_deleteUserById(Id) {

	$.ajax({
		async: true,
		type: "POST",
		url: "/User/DeleteUserById",
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
function js_addUser() {

	let User = {
		UserId: $('#txtUserId').val(),
		UserName: $('#txtUserName').val(),
		FirstName: $('#txtFirstName').val(),
		LastName: $('#txtLastName').val(),
		Title: $('#txtUnvan').val(),
		Active: chkKontrol('chkActive'),
		OfficeId: $('#selectOffice option:selected').val(),
		RoleTypeId: $('#selectRoleType option:selected').val()
	};

	$.ajax({
		async: true,
		type: "POST",
		url: "/User/AddUser",
		data: User,
		success: function (data) {
			var result = data;
			mesajBox('mesaj', 'DURUM', result, 'success');
			location.reload();
		},
		error: function (err) {
			if (err.status == 403) {
				mesajBox('mesaj', 'UYARI', "Bu İşlem İçin Yetkiniz Yok !", 'warning');
			}
			else {
				mesajBox('mesaj', 'UYARI', messageParse(err.responseText), 'warning');
            }

			
		}
	});


}

/** Şifre Değiştirme işlemi öncesi kullanıcıya son ikaz yapılır */
function js_changePasswordQ() {

	var oldPassword = $('#txtOldPassword').val();
	var newPassword = $('#txtNewPassword').val();
	var againNewPassword = $('#txtAgainNewPassword').val();


	if (oldPassword == null || oldPassword == "") {
		mesajBox('mesaj', 'UYARI', 'Eski Şifre Boş Olamaz !', 'warning');
		return;
	}

	if (newPassword == null || newPassword == "") {
		mesajBox('mesaj', 'UYARI', 'Yeni Şifre Boş Olamaz !', 'warning');
		return;
	}

	if (againNewPassword == null || againNewPassword == "") {
		mesajBox('mesaj', 'UYARI', 'Yeni Şifre Tekrarı Boş Olamaz !', 'warning');
		return;
	}

	mesajBox_confirm('Şifre Değiştir', 'Şifre Değiştir', 'Şifrenizi Değiştirmek İstediğinize Emin misiniz ?', 'Şifre Değiştir', 'warning', 'js_changePassword(\'' + oldPassword + '\',\'' + newPassword + '\',\''+againNewPassword+'\')');
}

/** Kullanıcı şifresi güncelleme işlemi yapılır. */
function js_changePassword(oldPassword, newPassword, againNewPassword) {

	$.ajax({
		async: true,
		type: "POST",
		url: "/User/ChangePassword",
		data: { oldPassword: oldPassword, newPassword: newPassword, againNewPassword: againNewPassword },
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

	



