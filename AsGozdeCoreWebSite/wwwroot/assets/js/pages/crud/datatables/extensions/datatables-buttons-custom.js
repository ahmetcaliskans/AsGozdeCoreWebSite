"use strict";

var DatatablesButtonsCashReport1 = function () {

	var initTableCashReport1 = function () {

		var table = $('#datatable_CashReport1').DataTable({
			responsive: true,
			// Pagination settings
			dom: `<'row'<'col-sm-6 text-left'f>>
			<'row'<'col-sm-12'tr>>
			<'row'<'col-sm-12 col-md-5'i><'col-sm-12 col-md-7 dataTables_pager'lp>>`,

			language: {
				url: '../assets/plugins/custom/datatables/datatables.turkish.json',
				decimal: ',',
				thousands: '.',
			},
			buttons: [
				'print',
				'copyHtml5',
				{
					extend: 'excelHtml5',
					text: 'Excel',
					exportOptions: {
						modifier: {
							page: 'all',
							search: 'none'
						},
						columns: [0, 1, 2, 3, 4]
					}
				},
				'csvHtml5',
				'pdfHtml5',
			],


			processing: false,
			serverSide: false,
			stateSave: false,
			ajax: {
				url: window.location.protocol + '//' + window.location.hostname + ':' + window.location.port + '/Report/GetCashReport1?collectionDefinitionTypeId=-99&expenseDefinitionId=-99',
				type: 'POST',
				dataSrc: '',
			},

			footerCallback: function (row, data, start, end, display) {
				var column = 2;
				var api = this.api(), data;

				// Remove the formatting to get integer data for summation
				var intVal = function (i) {
					return typeof i === 'string' ? i.replace(/[\$,]/g, '') * 1 : typeof i === 'number' ? i : 0;
				};

				// Total over all pages
				var total = api.column(column).data().reduce(function (a, b) {
					return intVal(a) + intVal(b);
				}, 0);

				// Total over this page
				var pageTotal = api.column(column, { page: 'current' }).data().reduce(function (a, b) {
					return intVal(a) + intVal(b);
				}, 0);

				// Update footer
				$(api.column(column).footer()).html(
					'' + pageTotal.toFixed(2) + '<br/> ( ' + total.toFixed(2) + ' Toplam)',
				);

				column = 3;
				api = this.api(), data;

				// Remove the formatting to get integer data for summation
				var intVal = function (i) {
					return typeof i === 'string' ? i.replace(/[\$,]/g, '') * 1 : typeof i === 'number' ? i : 0;
				};

				// Total over all pages
				var total = api.column(column).data().reduce(function (a, b) {
					return intVal(a) + intVal(b);
				}, 0);

				// Total over this page
				var pageTotal = api.column(column, { page: 'current' }).data().reduce(function (a, b) {
					return intVal(a) + intVal(b);
				}, 0);

				// Update footer
				$(api.column(column).footer()).html(
					'' + pageTotal.toFixed(2) + '<br/> ( ' + total.toFixed(2) + ' Toplam)',
				);

				column = 4;
				api = this.api(), data;

				// Remove the formatting to get integer data for summation
				var intVal = function (i) {
					return typeof i === 'string' ? i.replace(/[\$,]/g, '') * 1 : typeof i === 'number' ? i : 0;
				};

				// Total over all pages
				var total = api.column(column).data().reduce(function (a, b) {
					return intVal(a) + intVal(b);
				}, 0);

				// Total over this page
				var pageTotal = api.column(column, { page: 'current' }).data().reduce(function (a, b) {
					return intVal(a) + intVal(b);
				}, 0);

				// Update footer
				$(api.column(column).footer()).html(
					'' + pageTotal.toFixed(2) + '<br/> ( ' + total.toFixed(2) + ' Toplam)',
				);
			},

			//drawCallback: function () {
			//	var sum = $('#datatable_CashReport1').DataTable().column(4).data().sum();
			//	$('#total').html(sum);
			//},

			columns: [
				{ data: 'officeName' },
				{ data: 'paymentTypeName' },
				{ data: 'totalCollectionAmount' },
				{ data: 'totalExpenseAmount' },
				{ data: 'totalBalance' },
			],
			columnDefs: [
				{
					targets: 2,
					render: function (data, type, full, meta) {
						return data.toFixed(2);
					},
				},
				{
					targets: 3,
					render: function (data, type, full, meta) {
						return data.toFixed(2);
					},
				},
				{
					targets: 4,
					render: function (data, type, full, meta) {
						return data.toFixed(2);
					},
				},
			],
		});

		$('#export_print').on('click', function (e) {
			e.preventDefault();
			table.button(0).trigger();
		});

		$('#export_copy').on('click', function (e) {
			e.preventDefault();
			table.button(1).trigger();
		});

		$('#export_excel').on('click', function (e) {
			e.preventDefault();
			table.button(2).trigger();
		});

		$('#export_csv').on('click', function (e) {
			e.preventDefault();
			table.button(3).trigger();
		});

		$('#export_pdf').on('click', function (e) {
			e.preventDefault();
			table.button(4).trigger();
		});

	};

	return {

		//main function to initiate the module
		init: function () {
			initTableCashReport1();
		},

	};

}();

var DatatablesButtonsCashReport1DetailCollection = function () {

	var initTableCashReport1DetailCollection = function () {

		var table = $('#datatable_CashReport1DetailCollection').DataTable({
			responsive: true,
			// Pagination settings
			dom: `<'row'<'col-sm-6 text-left'f>>
			<'row'<'col-sm-12'tr>>
			<'row'<'col-sm-12 col-md-5'i><'col-sm-12 col-md-7 dataTables_pager'lp>>`,

			language: {
				url: '../assets/plugins/custom/datatables/datatables.turkish.json',
				decimal: ',',
				thousands: '.',
			},
			buttons: [
				'print',
				'copyHtml5',
				{
					extend: 'excelHtml5',
					text: 'Excel',
					exportOptions: {
						modifier: {
							page: 'all',
							search: 'none'
						},
						columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11]
					}
				},
				'csvHtml5',
				'pdfHtml5',
			],


			processing: false,
			serverSide: false,
			stateSave: false,
			ajax: {
				url: window.location.protocol + '//' + window.location.hostname + ':' + window.location.port + '/Report/GetCashReport1DetailCollection?collectionDefinitionTypeId=-99',
				type: 'POST',
				dataSrc:'',
			},

			footerCallback: function (row, data, start, end, display) {
				var column = 10;
				var api = this.api(), data;

				// Remove the formatting to get integer data for summation
				var intVal = function (i) {
					return typeof i === 'string' ? i.replace(/[\$,]/g, '') * 1 : typeof i === 'number' ? i : 0;
				};

				// Total over all pages
				var total = api.column(column).data().reduce(function (a, b) {
					return intVal(a) + intVal(b);
				}, 0);

				// Total over this page
				var pageTotal = api.column(column, { page: 'current' }).data().reduce(function (a, b) {
					return intVal(a) + intVal(b);
				}, 0);

				// Update footer
				$(api.column(column).footer()).html(
					'' + pageTotal.toFixed(2) + '<br/> ( ' + total.toFixed(2) + ' Toplam)',
				);				
			},

			columns: [
				{ data: 'nameSurname' },
				{ data: 'identityNo' },
				{ data: 'phone1' },
				{ data: 'sessionName' },
				{ data: 'branchName' },
				{ data: 'officeName' },
				{ data: 'collectionDefinitionTypeName' },
				{ data: 'collectionDefinitionName' },
				{ data: 'paymentName' },
				{ data: 'collectionDate' },
				{ data: 'amount' },
				{ data: 'hour' },				
			],
			columnDefs: [
				{
					targets: 10,
					render: function (data, type, full, meta) {						
						return data.toFixed(2);
					},
				},
				{
					targets: 11,
					render: function (data, type, full, meta) {
						return data.toFixed(2);
					},
				},
			],
		});

		$('#export_print_detailCollection').on('click', function (e) {
			e.preventDefault();
			table.button(0).trigger();
		});

		$('#export_copy_detailCollection').on('click', function (e) {
			e.preventDefault();
			table.button(1).trigger();
		});

		$('#export_excel_detailCollection').on('click', function (e) {
			e.preventDefault();
			table.button(2).trigger();
		});

		$('#export_csv_detailCollection').on('click', function (e) {
			e.preventDefault();
			table.button(3).trigger();
		});

		$('#export_pdf_detailCollection').on('click', function (e) {
			e.preventDefault();
			table.button(4).trigger();
		});

	};

	return {

		//main function to initiate the module
		init: function () {
			initTableCashReport1DetailCollection();
		},

	};

}();

var DatatablesButtonsCashReport1DetailExpense = function () {

	var initTableCashReport1DetailExpense = function () {

		var table = $('#datatable_CashReport1DetailExpense').DataTable({
			responsive: true,
			// Pagination settings
			dom: `<'row'<'col-sm-6 text-left'f>>
			<'row'<'col-sm-12'tr>>
			<'row'<'col-sm-12 col-md-5'i><'col-sm-12 col-md-7 dataTables_pager'lp>>`,

			language: {
				url: '../assets/plugins/custom/datatables/datatables.turkish.json',
				decimal: ',',
				thousands: '.',
			},
			buttons: [
				'print',
				'copyHtml5',
				{
					extend: 'excelHtml5',
					text: 'Excel',
					exportOptions: {
						modifier: {
							page: 'all',
							search: 'none'
						},
						columns: [0, 1, 2, 3, 4, 5, 6, 7, 8]
					}
				},
				'csvHtml5',
				'pdfHtml5',
			],


			processing: false,
			serverSide: false,
			stateSave: false,
			ajax: {
				url: window.location.protocol + '//' + window.location.hostname + ':' + window.location.port + '/Report/GetCashReport1DetailExpense?expenseDefinitionId=-99',
				type: 'POST',
				dataSrc: '',
			},

			footerCallback: function (row, data, start, end, display) {
				var column = 7;
				var api = this.api(), data;

				// Remove the formatting to get integer data for summation
				var intVal = function (i) {
					return typeof i === 'string' ? i.replace(/[\$,]/g, '') * 1 : typeof i === 'number' ? i : 0;
				};

				// Total over all pages
				var total = api.column(column).data().reduce(function (a, b) {
					return intVal(a) + intVal(b);
				}, 0);

				// Total over this page
				var pageTotal = api.column(column, { page: 'current' }).data().reduce(function (a, b) {
					return intVal(a) + intVal(b);
				}, 0);

				// Update footer
				$(api.column(column).footer()).html(
					'' + pageTotal.toFixed(2) + '<br/> ( ' + total.toFixed(2) + ' Toplam)',
				);
			},

			columns: [
				{ data: 'documentNo' },
				{ data: 'expenseDate' },
				{ data: 'description' },
				{ data: 'paymentTypeName' },
				{ data: 'expenseDefinitionName' },
				{ data: 'fixtureDefinitionName' },
				{ data: 'personnelNameSurname' },
				{ data: 'amount' },
				{ data: 'officeName' },
			],
			columnDefs: [
				{
					targets: 7,
					render: function (data, type, full, meta) {
						return data.toFixed(2);
					},
				},
			],
		});

		$('#export_print_detailExpense').on('click', function (e) {
			e.preventDefault();
			table.button(0).trigger();
		});

		$('#export_copy_detailExpense').on('click', function (e) {
			e.preventDefault();
			table.button(1).trigger();
		});

		$('#export_excel_detailExpense').on('click', function (e) {
			e.preventDefault();
			table.button(2).trigger();
		});

		$('#export_csv_detailExpense').on('click', function (e) {
			e.preventDefault();
			table.button(3).trigger();
		});

		$('#export_pdf_detailExpense').on('click', function (e) {
			e.preventDefault();
			table.button(4).trigger();
		});

	};

	return {

		//main function to initiate the module
		init: function () {
			initTableCashReport1DetailExpense();
		},

	};

}();



jQuery(document).ready(function () {
	DatatablesButtonsCashReport1.init();
	DatatablesButtonsCashReport1DetailCollection.init();
	DatatablesButtonsCashReport1DetailExpense.init();
	
});

