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

/** Şube tanımı ekleme yada güncelleme işlemi yapılır. */
function js_addUser() {

	var a = $('#chkActive:checked').val();
	var b = a;

	let User = {
		UserId: $('#txtUserId').val(),
		UserName: $('#txtUserName').val(),
		FirstName: $('#txtFirstName').val(),
		LastName: $('#txtLastName').val(),
		Active: chkKontrol('chkActive')
	};

	if (User.UserName != null && User.UserName != "") {
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
				mesajBox('mesaj', 'UYARI', err.responseText, 'warning');
			}
		});
	}
	else
		mesajBox('mesaj', 'UYARI', 'Kullanıcı Kodu Boş Olamaz !', 'warning');


}

