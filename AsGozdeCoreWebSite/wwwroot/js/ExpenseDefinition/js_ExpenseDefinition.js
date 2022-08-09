const { Alert } = require("bootstrap");

/***** Id ile gider tanımları tanımı getirilir *****/
function js_getExpenseDefinitionById(Id) {
	$('#dataExpenseDefinition').html("");

	$.ajax({
		async: true,
		type: "GET",
		url: "/ExpenseDefinition/GetExpenseDefinitionById",
		data: { id: Id },
		contentType: "application/json; charset=utf-8",
		dataType: "html",
		success: function (data) {
			var result = data;
			$('#dataExpenseDefinition').html("");
			$('#dataExpenseDefinition').html(result);
		},
		error: function (err) {
			mesajBox('mesaj', 'UYARI', err.html, 'warning');
		}
	});

}

/** Silme işlemi öncesi kullanıcıya son ikaz yapılır */
function js_deleteExpenseDefinitionByIdQ(Id) {
	mesajBox_confirm('Sil', 'Sil', 'Tanımı Silmek İstediğinize Emin misiniz ?', 'Sil', 'danger', 'js_deleteExpenseDefinitionById(' + Id + ')');
}

/***** Id ile gider tanımları tanımı silme işlemi yapılır. *****/
function js_deleteExpenseDefinitionById(Id) {

	$.ajax({
		async: true,
		type: "POST",
		url: "/ExpenseDefinition/DeleteExpenseDefinitionById",
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

/** gider tanımları tanımı ekleme yada güncelleme işlemi yapılır. */
function js_addExpenseDefinition() {

	let ExpenseDefinition = {
		Id: $('#txtId').val(),
		Name: $('#txtName').val(),
		Description: $('#txtDescription').val(),
		IsFixtureCanBeSelected: chkKontrol('chkIsFixtureCanBeSelected'),
		IsFixtureSelectionRequired: chkKontrol('chkIsFixtureSelectionRequired'),
		IsPersonnelCanBeSelected: chkKontrol('chkIsPersonnelCanBeSelected'),
		IsPersonnelSelectionRequired: chkKontrol('chkIsPersonnelSelectionRequired'),
		Active: chkKontrol('chkActive')
	};

	$.ajax({
		async: true,
		type: "POST",
		url: "/ExpenseDefinition/AddExpenseDefinition",
		data: ExpenseDefinition,
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

