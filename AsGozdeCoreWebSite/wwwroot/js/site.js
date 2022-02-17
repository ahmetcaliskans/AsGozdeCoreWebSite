// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

/***** Message Box Onaylı *****/
function mesajBox_confirm(id, baslik, mesaj, butonAdi, renk ,onClickFonksiyon) {
	//Kontrol işlemini yapmassam her seferinde yeni modal oluşturuyor.
	$('#' + id).remove();
	var mesajs =
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

	$(mesajs).modal();


}

/***** Message Box *****/
function mesajBox(id, baslik, mesaj, renk) {
	var mesajkontrol = $('#' + id).val();

	$('#' + id).remove();
	var mesaj =
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
		'<button type="button" data-dismiss="modal" class="btn btn-' + renk + '"">Tamam</button>' +
		' </div>' +
		'</div>' +
		'</div>' +
		'</div>'

	$(mesaj).modal();
}

/***** CheckBox Valuesini Al *****/
function chkKontrol(chkbox) {
	var chkboxvalue = null;
	chkboxvalue = $('#' + chkbox.toString() + ':checked').val();
	if (chkboxvalue == null)
		return false;

	return true;
}

/***** Numeric Alanlar İçin Decimal Değerler  Miktar ,  BirimFiyat , Tutar *****/
$('.mynumeric4').numeric({ decimal: ",", negative: false, decimalPlaces: 4 });

$('.mynumeric6').numeric({ decimal: ",", negative: false, decimalPlaces: 6 });

$('.mynumeric2').numeric({ decimal: ",", negative: false, decimalPlaces: 2 });

$(".mydate").inputmask({ mask: "99.99.9999" });
