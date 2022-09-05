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

			order: [],

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

			order: [],

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
					targets: 9,
					type: 'datetime',
					render: function (data, type, full, meta) {
						return moment(data).format("YYYY-MM-DD");
					},
				},
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
			order: [],
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
					targets: 1,
					type: 'datetime',
					render: function (data, type, full, meta) {
						return moment(data).format("YYYY-MM-DD");
					},
				},
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

var DatatablesButtonsListOfDueCoursePaymentsReport = function () {

	var initTableListOfDueCoursePaymentsReport = function () {

		var table = $('#datatable_ListOfDueCoursePaymentsReport').DataTable({
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
				url: window.location.protocol + '//' + window.location.hostname + ':' + window.location.port + '/Report/GetListOfDueCoursePayments?dueType=0',
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

				column = 8;
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
					'' + pageTotal.toFixed(2) + '<br/> ( ' + total.toFixed(2) + ' Toplam Borç)',
				);
				
			},

			//drawCallback: function () {
			//	var sum = $('#datatable_CashReport1').DataTable().column(4).data().sum();
			//	$('#total').html(sum);
			//},

			order: [],

			columns: [
				{ data: 'nameSurname' },
				{ data: 'identityNo' },
				{ data: 'phone1' },
				{ data: 'courseFee' },
				{ data: 'courseFeePlus' },
				{ data: 'collectionDefinitionTypeName' },
				{ data: 'paymentDate' },
				{ data: 'amount' },
				{ data: 'debitinMonth' },
				{ data: 'sessionName' },
				{ data: 'branchName' },
				{ data: 'officeName' },
				{ data: 'driverPaymentPlanId' },
			],
			columnDefs: [
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
				{
					targets: 6,
					type: 'datetime',
					render: function (data, type, full, meta) {
						return moment(data).format("YYYY-MM-DD");
					},
				},
				{
					targets: 7,
					render: function (data, type, full, meta) {
						return data.toFixed(2);
					},
				},
				{
					targets: 8,
					render: function (data, type, full, meta) {
						return data.toFixed(2);
					},
				},
				{
					targets: 12,
					autoHide: false,
					render: function (data, type, full, meta) {
						return '\
							<a class="btn btn-sm btn-clean btn-icon" title="Surucu Adayi Bilgileri" href="/Driver/GetDriverByIdWithDetails/'+ data + '">\
									<span class="svg-icon svg-icon-md">\
										<svg xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" width="24px" height="24px" viewBox="0 0 24 24" version="1.1">\
											<g stroke = "none" stroke - width="1" fill = "none" fill - rule="evenodd" >\
												<polygon points="0 0 24 0 24 24 0 24"/>\
												<rect fill="#000000" opacity="0.3" transform="translate(12.000000, 12.000000) rotate(-90.000000) translate(-12.000000, -12.000000) " x="11" y="5" width="2" height="14" rx="1"/>\
												<path d="M9.70710318,15.7071045 C9.31657888,16.0976288 8.68341391,16.0976288 8.29288961,15.7071045 C7.90236532,15.3165802 7.90236532,14.6834152 8.29288961,14.2928909 L14.2928896,8.29289093 C14.6714686,7.914312 15.281055,7.90106637 15.675721,8.26284357 L21.675721,13.7628436 C22.08284,14.136036 22.1103429,14.7686034 21.7371505,15.1757223 C21.3639581,15.5828413 20.7313908,15.6103443 20.3242718,15.2371519 L15.0300721,10.3841355 L9.70710318,15.7071045 Z" fill="#000000" fill-rule="nonzero" transform="translate(14.999999, 11.999997) scale(1, -1) rotate(90.000000) translate(-14.999999, -11.999997) "/>\
											</g >\
										</svg >\
									</span >\
							   </a >\
							';
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
			initTableListOfDueCoursePaymentsReport();
		},

	};

}();



jQuery(document).ready(function () {
	DatatablesButtonsCashReport1.init();
	DatatablesButtonsCashReport1DetailCollection.init();
	DatatablesButtonsCashReport1DetailExpense.init();
	DatatablesButtonsListOfDueCoursePaymentsReport.init();
	
});

