

/***** Id ile Tahsilat tanımı getirilir *****/
function js_getExpenseByIdWithDetails(Id) {
	$.ajax({
		async: true,
		type: "GET",
		url: "/Expense/GetExpenseByIdWithDetails",
		data: { id: Id },
		contentType: "application/json; charset=utf-8",
		dataType: "html",
		success: function (data) {
			var result = data;
			$('#dataExpense').html("");
			$('#dataExpense').html(result);
		},
		error: function (err) {
			mesajBox('mesaj', 'UYARI', err.html, 'warning');
		}
	});

}

/** Silme işlemi öncesi kullanıcıya son ikaz yapılır */
function js_deleteExpenseByIdQ(Id) {
	if (Id > 0) {
		mesajBox_confirm('Sil', 'Sil', 'Tanımı Silmek İstediğinize Emin misiniz ?', 'Sil', 'danger', 'js_deleteExpenseById(' + Id + ')');
	}

}

/***** Id ile Tahsilat silme işlemi yapılır. *****/
function js_deleteExpenseById(Id) {

	$.ajax({
		async: true,
		type: "POST",
		url: "/Expense/DeleteExpenseById",
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

/** Tahsilat ekleme yada güncelleme işlemi yapılır. */
function js_addExpense(islem) {	

	var expenseDate = $('input[name="txtExpenseDate"]').val();
	if (expenseDate == null || expenseDate == "") {
		mesajBox('mesaj', 'UYARI', 'Lütfen Bir Tarih Seçiniz !', 'warning');
		return;
	}

	let expense = {
		Id: $('#txtId').val(),
		ExpenseDate: expenseDate,
		PaymentTypeId: $('#selectPaymentType option:selected').val(),
		ExpenseDefinitionId: $('#selectExpenseDefinition option:selected').val(),
		FixtureDefinitionId: $('#selectFixtureDefinition option:selected').val(),
		PersonnelDefinitionId: $('#selectPersonnelDefinition option:selected').val(),
		Description: $('#txtDescription').val(),
		Amount: $('#txtAmount').val()
	};


	$.ajax({
		async: true,
		type: "POST",
		url: "/Expense/AddExpense",
		data: expense,
		success: function (data) {
			var result = data;
			mesajBox('mesaj', 'DURUM', result[0], 'success');
			location.reload();

		},
		error: function (err) {
			mesajBox('mesaj', 'UYARI', err.responseText, 'warning');
		}
	});


}




/***** Tahsilat Tipi Değiştiğince mevcut tipin özelliklerine göre saat yada kendi ödeyebilir seçeneklerini gösteriyor yada gizliyorum. *****/
function js_checkExpenseDefinitionInformations() {
	var Id = document.getElementById("selectExpenseDefinition").value;
	$.ajax({
		async: true,
		type: "POST",
		url: "/Expense/GetExpenseDefinitionInformations",
		data: { id: Id },
		success: function (data) {
			var result = data;
			var resultSplit = result.split('/');

			/** Demirbaş Seçilebilir Özelliği varsa **/
			if (resultSplit[0] == "True") {
				document.getElementById("divIsFixtureDefinitionCanBeSelected").removeAttribute("hidden");
			}
			else {
				document.getElementById("divIsFixtureDefinitionCanBeSelected").setAttribute("hidden", "hidden");

			}

			/** Personel Seçilebilir Özelliği varsa **/
			if (resultSplit[1] == "True") {
				document.getElementById("divIsPersonnelDefinitionCanBeSelected").removeAttribute("hidden");
			}
			else {
				document.getElementById("divIsPersonnelDefinitionCanBeSelected").setAttribute("hidden", "hidden");

			}

		},
		error: function (err) {
			if (err.responseText.indexOf('FK_') > -1)
				mesajBox('mesaj', 'UYARI', 'Bu Tanım Kullanılıyor !', 'warning');
			else
				mesajBox('mesaj', 'UYARI', err.responseText, 'danger');
		}
	});
}

