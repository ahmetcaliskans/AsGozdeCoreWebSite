const { Alert } = require("bootstrap");

/***** Id ile ödeme tipi tanımı getirilir *****/
function js_getPaymentTypeById(Id) {
	$('#dataPaymentType').html("");

	$.ajax({
		async: true,
		type: "GET",
		url: "/PaymentType/GetPaymentTypeById",
		data: { id: Id },
		contentType: "application/json; charset=utf-8",
		dataType: "html",
		success: function (data) {
			var result = data;
			$('#dataPaymentType').html("");
			$('#dataPaymentType').html(result);
		},
		error: function (err) {
			mesajBox('mesaj', 'UYARI', err.html, 'warning');
		}
	});

}

/** Silme işlemi öncesi kullanıcıya son ikaz yapılır */
function js_deletePaymentTypeByIdQ(Id) {
	mesajBox_confirm('Sil', 'Sil', 'Tanımı Silmek İstediğinize Emin misiniz ?', 'Sil', 'danger', 'js_deletePaymentTypeById(' + Id + ')');
}

/***** Id ile ödeme tipi tanımı silme işlemi yapılır. *****/
function js_deletePaymentTypeById(Id) {

	$.ajax({
		async: true,
		type: "POST",
		url: "/PaymentType/DeletePaymentTypeById",
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

/** ödeme tipi tanımı ekleme yada güncelleme işlemi yapılır. */
function js_addPaymentType() {

	let PaymentType = {
		Id: $('#txtId').val(),
		Name: $('#txtName').val(),
		Description: $('#txtDescription').val(),
		Active: chkKontrol('chkActive')
	};

	if (PaymentType.Name != null && PaymentType.Name != "") {
		$.ajax({
			async: true,
			type: "POST",
			url: "/PaymentType/AddPaymentType",
			data: PaymentType,
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

