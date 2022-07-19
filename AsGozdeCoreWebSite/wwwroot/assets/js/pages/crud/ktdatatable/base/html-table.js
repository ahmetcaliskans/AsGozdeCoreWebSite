"use strict";
// Class definition

var KTDatatableHtmlTableDemo = function() {
    // Private functions

    // demo initializer
    var demo = function() {

		var datatable = $('#kt_datatable').KTDatatable({
			data: {
				saveState: false,
				pageSize: 10
			},
			search: {
				input: $('#kt_datatable_search_query'),
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


		//$('#kt_datatable_search_sessionName').on('change', function () {
		//	datatable.search($(this).val().toLowerCase(), 'sessionName');
		//});

		//$('#kt_datatable_search_sessionName').selectpicker();

    };

    return {
        // Public functions
        init: function() {
            // init dmeo
            demo();
        },
    };
}();

jQuery(document).ready(function() {
	KTDatatableHtmlTableDemo.init();
});
