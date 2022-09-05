
/***** Message Box Onaylı *****/
function mesajBox_confirm(id, baslik, mesaj, butonAdi, renk ,onClickFonksiyon) {
	//Kontrol işlemini yapmassam her seferinde yeni modal oluşturuyor.
	$('#' + id).remove();
	var messageModal =
		'<div id="' + id + '" class="modal fade" tabindex="-1" data-backdrop="' + id + '" data-keyboard="true">' +
		'<div class="modal-dialog">' +
		' <div class="modal-content">' +
		'<div class="modal-header">' +
		'<button type="button" class="close" data-dismiss="modal" aria-hidden="true"></button>' +
		'<h4 class="modal-title">' + baslik + '</h4>' +
		'</div>' +
		'<div class="modal-body">' +
		'<p>' + mesaj + '</p>' +
		'</div>' +
		'<div class="modal-footer">' +
		'<button type="button" data-dismiss="modal" class="btn btn-default">Vazgeç</button>' +
		'<button type="button" data-dismiss="modal" class="btn btn-'+renk+'"  onclick="' + onClickFonksiyon + '">'+butonAdi+'</button>' +
		' </div>' +
		'</div>' +
		'</div>' +
		'</div>'

	$(messageModal).modal();
}

/***** Message Box *****/
function mesajBox(id, baslik, mesaj, renk) {
	var mesajkontrol = $('#' + id).val();	 

	mesaj = messageParse(mesaj);

	$('#' + id).remove();
	var messageModal =
		'<div id="' + id + '" class="modal fade" tabindex="-1" data-backdrop="' + id + '" data-keyboard="true">' +
		'<div class="modal-dialog">' +
		' <div class="modal-content">' +
		'<div class="modal-header">' +
		'<button type="button" class="close" data-dismiss="modal" aria-hidden="true"></button>' +
		'<h4 class="modal-title">' + baslik + '</h4>' +
		'</div>' +
		'<div class="modal-body">' +
		'<p>' + mesaj + '</p>' +
		'</div>' +
		'<div class="modal-footer">' +
		'<button type="button" data-dismiss="modal" class="btn btn-' + renk + '">Tamam</button>' +
		' </div>' +
		'</div>' +
		'</div>' +
		'</div>'

	$(messageModal).modal();

}

/***** CheckBox Valuesini Al *****/
function chkKontrol(chkbox) {
	var chkboxvalue = null;
	chkboxvalue = $('#' + chkbox.toString() + ':checked').val();
	if (chkboxvalue == null)
		return false;

	return true;
}

function messageParse(message) {

	if (message.indexOf('FluentValidation.ValidationException:') > -1) {
		var messages = message.split(' at Core');
		return messages[0].replace('FluentValidation.ValidationException: Validation failed: ', '').split('Severity: Error').join('').split('--').join('<br\>');
	}
	else if (message.indexOf('System.ApplicationException:') > -1) {
		var messages = message.split(' at Business');
		return messages[0].replace('System.ApplicationException: ', '');
	}
	else if (message.indexOf('FK_') > -1) {		
		return 'Bu Tanım Kullanılıyor !';
	}

	return message;
}

$(document).ready(function () {
	const driverElement = document.getElementById('liDriver');
	const driverlistItems = driverElement.getElementsByTagName('li');
	if (driverlistItems.length == 1) {
		driverElement.hidden = true;
	}
	else {
		driverElement.hidden = false;
    }

	const paymentElement = document.getElementById('liPayment');
	const paymentlistItems = paymentElement.getElementsByTagName('li');
	if (paymentlistItems.length == 1) {
		paymentElement.hidden = true;
	}
	else {
		paymentElement.hidden = false;
	}

	const reportElement = document.getElementById('liReport');
	const reportlistItems = reportElement.getElementsByTagName('li');
	if (reportlistItems.length == 1) {
		reportElement.hidden = true;
	}
	else {
		reportElement.hidden = false;
	}

	const dashboardElement = document.getElementById('liDashboard');
	const dashboardlistItems = dashboardElement.getElementsByTagName('li');
	if (dashboardlistItems.length == 1) {
		dashboardElement.hidden = true;
	}
	else {
		dashboardElement.hidden = false;
	}

	const settingsElement = document.getElementById('liSettings');
	const settingslistItems = settingsElement.getElementsByTagName('li');
	if (settingslistItems.length == 1) {
		settingsElement.hidden = true;
	}
	else {
		settingsElement.hidden = false;
	}
});


///***** Numeric Alanlar İçin Decimal Değerler  Miktar ,  BirimFiyat , Tutar *****/
//$('.mynumeric4').numeric({ decimal: ",", negative: false, decimalPlaces: 4 });

//$('.mynumeric6').numeric({ decimal: ",", negative: false, decimalPlaces: 6 });

//$('.mynumeric2').numeric({ decimal: ",", negative: false, decimalPlaces: 2 });

//$(".mydate").inputmask({ mask: "99.99.9999" });
