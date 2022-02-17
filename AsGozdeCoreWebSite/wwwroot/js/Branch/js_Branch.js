const { Alert } = require("bootstrap");

/***** Id ile şube tanımı getirilir *****/
function js_getBranchById(Id) {
	$('#dataBranch').html("");

	$.ajax({
		async: true,
		type: "GET",
		url: "/Branch/GetBranchById",
		data: { id: Id },
		contentType: "application/json; charset=utf-8",
		dataType: "html",
		success: function (data) {
			var result = data;
			$('#dataBranch').html("");
			$('#dataBranch').html(result);
		},
		error: function (err) {
			mesajBox('mesaj', 'UYARI', err.html, 'warning');
		}
	});

}

/** Silme işlemi öncesi kullanıcıya son ikaz yapılır */
function js_deleteBranchByIdQ(Id) {
	mesajBox_confirm('Sil', 'Sil', 'Tanımı Silmek İstediğinize Emin misiniz ?', 'Sil', 'danger', 'js_deleteBranchById(' + Id + ')');
}

/***** Id ile şube tanımı silme işlemi yapılır. *****/
function js_deleteBranchById(Id) {

	$.ajax({
		async: true,
		type: "POST",
		url: "/Branch/DeleteBranchById",
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
function js_addBranch() {

	let Branch = {
		Id: $('#txtId').val(),
		Name: $('#txtName').val(),
		Description: $('#txtDescription').val()
	};

	if (Branch.Name != null && Branch.Name != "") {
		$.ajax({
			async: true,
			type: "POST",
			url: "/Branch/AddBranch",
			data: Branch,
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
		mesajBox('mesaj', 'UYARI', 'Branş Adı Boş Olamaz !', 'warning');


}

