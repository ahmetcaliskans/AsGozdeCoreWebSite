const { Alert } = require("bootstrap");

/***** Id ile personel tanımları tanımı getirilir *****/
function js_getPersonnelDefinitionById(Id) {
	$('#dataPersonnelDefinition').html("");

	$.ajax({
		async: true,
		type: "GET",
		url: "/PersonnelDefinition/GetPersonnelDefinitionById",
		data: { id: Id },
		contentType: "application/json; charset=utf-8",
		dataType: "html",
		success: function (data) {
			var result = data;
			$('#dataPersonnelDefinition').html("");
			$('#dataPersonnelDefinition').html(result);
		},
		error: function (err) {
			mesajBox('mesaj', 'UYARI', err.html, 'warning');
		}
	});

}

/** Silme işlemi öncesi kullanıcıya son ikaz yapılır */
function js_deletePersonnelDefinitionByIdQ(Id) {
	mesajBox_confirm('Sil', 'Sil', 'Tanımı Silmek İstediğinize Emin misiniz ?', 'Sil', 'danger', 'js_deletePersonnelDefinitionById(' + Id + ')');
}

/***** Id ile personel tanımları tanımı silme işlemi yapılır. *****/
function js_deletePersonnelDefinitionById(Id) {

	$.ajax({
		async: true,
		type: "POST",
		url: "/PersonnelDefinition/DeletePersonnelDefinitionById",
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

/** personel tanımları tanımı ekleme yada güncelleme işlemi yapılır. */
function js_addPersonnelDefinition() {

	var imgPersonnel = $('#imgPersonnel').css('background-image');
	imgPersonnel = imgPersonnel.replace('url(', '').replace(')', '').replace(/\"/gi, "");

	if (imgPersonnel.indexOf('data') < 0) {
		imgPersonnel = null;
	}

	let PersonnelDefinition = {
		Id: $('#txtId').val(),
		Name: $('#txtName').val(),
		Surname: $('#txtSurname').val(),		
		IdentityNo: $('#txtIdentityNo').val(),
		Job: $('#txtJob').val(),
		Position: $('#txtPosition').val(),
		Salary: $('#txtSalary').val(),
		Email: $('#txtEmail').val(),
		Phone1: $('#txtPhone1').val(),
		Phone2: $('#txtPhone2').val(),
		City: $('#txtCity').val(),
		County: $('#txtCounty').val(),
		Address1: $('#txtAddress1').val(),
		Address2: $('#txtAddress2').val(),
		Image: imgPersonnel,
		Note: $('#txtNote').val(),
		StartDate: $('input[name="txtStartDate"]').val(),
		EndDate: $('input[name="txtEndDate"]').val(),
		Active: chkKontrol('chkActive')
	};

	$.ajax({
		async: true,
		type: "POST",
		url: "/PersonnelDefinition/AddPersonnelDefinition",
		data: PersonnelDefinition,
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

