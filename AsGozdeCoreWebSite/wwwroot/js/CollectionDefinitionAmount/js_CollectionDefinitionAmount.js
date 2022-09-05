const { Alert } = require("bootstrap");

/***** Id ile tahsilat tanımları tanımı getirilir *****/
function js_getCollectionDefinitionAmountById(Id) {
	$('#dataCollectionDefinitionAmount').html("");

	$.ajax({
		async: true,
		type: "GET",
		url: "/CollectionDefinitionAmount/GetCollectionDefinitionAmountById",
		data: { id: Id },
		contentType: "application/json; charset=utf-8",
		dataType: "html",
		success: function (data) {
			var result = data;
			$('#dataCollectionDefinitionAmount').html("");
			$('#dataCollectionDefinitionAmount').html(result);
		},
		error: function (err) {
			mesajBox('mesaj', 'UYARI', err.html, 'warning');
		}
	});

}

/** Silme işlemi öncesi kullanıcıya son ikaz yapılır */
function js_deleteCollectionDefinitionAmountByIdQ(Id) {
	mesajBox_confirm('Sil', 'Sil', 'Tanımı Silmek İstediğinize Emin misiniz ?', 'Sil', 'danger', 'js_deleteCollectionDefinitionAmountById(' + Id + ')');
}

/***** Id ile tahsilat tanımları tanımı silme işlemi yapılır. *****/
function js_deleteCollectionDefinitionAmountById(Id) {

	$.ajax({
		async: true,
		type: "POST",
		url: "/CollectionDefinitionAmount/DeleteCollectionDefinitionAmountById",
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

/** tahsilat tanımları tanımı ekleme yada güncelleme işlemi yapılır. */
function js_addCollectionDefinitionAmount() {

	let CollectionDefinitionAmount = {
		Id: $('#txtId').val(),
		CollectionDefinitionId: $('#selectCollectionDefinition option:selected').val(),
		Year: $('#txtYear').val(),
		Amount: $('#txtAmount').val()		
	};

	$.ajax({
		async: true,
		type: "POST",
		url: "/CollectionDefinitionAmount/AddCollectionDefinitionAmount",
		data: CollectionDefinitionAmount,
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

