"use strict";
// Class definition

var KTDatatableHtmlTableDemo2 = function () {
	// Private functions

	// demo initializer
	var demo2 = function () {

		var datatable = $('#kt_datatable2').KTDatatable({
			data: {
				saveState: false
			},
			search: {
				input: $('#kt_datatable_search_query2'),
				key: 'generalSearch'
			},			
			columns: [
				{
					field: 'Islem',
					autoHide: false,
					sortable: false
				}
			],
		});
		

		//$('#kt_datatable_search_donem').on('change', function () {
		//	datatable.search($(this).val().toLowerCase(), 'Donem');
		//});
		
		//$('#kt_datatable_search_donem').selectpicker();

	};

	return {
		// Public functions
		init: function () {
			// init dmeo2
			demo2();
		},
	};
}();

jQuery(document).ready(function () {
	KTDatatableHtmlTableDemo2.init();
});
