"use strict";

var DatatablesButtonsDriverInformations = function () {

	var initTableDriverInformations = function () {

		var certificateState = $('#selectCertificateState option:selected').val();

		var table = $('#datatable_DriverInformations').DataTable({
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
							search: 'applied'
						},
						columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9],
						format: {
							body: function (data, row, column, node) {
								data = $('<p>' + data + '</p>').text();
								return $.isNumeric(data.replace('.', '').replace(',', '.')) ? data.replace('.', '').replace(',', '.') : data;
							}
						}
					}
				},
				'csvHtml5',
				'pdfHtml5',
			],
			
			processing: false,
			serverSide: false,
			stateSave: false,
			ajax: {
				url: window.location.protocol + '//' + window.location.hostname + ':' + window.location.port + '/Driver/GetListOfDriverInformationByOfficeIdAndCertificate?certificateState=' + certificateState + '',
				type: 'POST',
				dataSrc: '',
			},

			footerCallback: function (row, data, start, end, display) {
				var column = 3;
				var api = this.api(), data;
				// Remove the formatting to get integer data for summation
				var intVal = function (i) {
					return typeof i === 'string' ? i.replace(/[\$,]/g, '') * 1 : typeof i === 'number' ? i : 0;
				};

				// Total over all pages filtered
				var total = api.column(column, { search: 'applied', page: 'all' }).data().reduce(function (a, b) {
					return intVal(a) + intVal(b);
				}, 0);				

				// Total over this page
				var pageTotal = api.column(column, { page: 'current' }).data().reduce(function (a, b) {
					return intVal(a) + intVal(b);
				}, 0);

				// Update footer
				$(api.column(column).footer()).html(
					'' + pageTotal.toFixed(2).replace('.', ',').replace(/(\d)(?=(\d{3})+(?!\d))/g, '$1.') + '<br/> (' + total.toFixed(2).replace('.', ',').replace(/(\d)(?=(\d{3})+(?!\d))/g, '$1.') + ')',
				);


				var column = 4;
				var api = this.api(), data;
				// Remove the formatting to get integer data for summation
				var intVal = function (i) {
					return typeof i === 'string' ? i.replace(/[\$,]/g, '') * 1 : typeof i === 'number' ? i : 0;
				};

				// Total over all pages filtered
				var total = api.column(column, { search: 'applied', page: 'all' }).data().reduce(function (a, b) {
					return intVal(a) + intVal(b);
				}, 0);

				// Total over this page
				var pageTotal = api.column(column, { page: 'current' }).data().reduce(function (a, b) {
					return intVal(a) + intVal(b);
				}, 0);

				// Update footer
				$(api.column(column).footer()).html(
					'' + pageTotal.toFixed(2).replace('.', ',').replace(/(\d)(?=(\d{3})+(?!\d))/g, '$1.') + '<br/> (' + total.toFixed(2).replace('.', ',').replace(/(\d)(?=(\d{3})+(?!\d))/g, '$1.') + ')',
				);


				column = 5;
				api = this.api(), data;
				// Remove the formatting to get integer data for summation
				var intVal = function (i) {
					return typeof i === 'string' ? i.replace(/[\$,]/g, '') * 1 : typeof i === 'number' ? i : 0;
				};

				// Total over all pages filtered
				var total = api.column(column, { search: 'applied', page: 'all' }).data().reduce(function (a, b) {
					return intVal(a) + intVal(b);
				}, 0);

				// Total over this page
				var pageTotal = api.column(column, { page: 'current' }).data().reduce(function (a, b) {
					return intVal(a) + intVal(b);
				}, 0);

				// Update footer
				$(api.column(column).footer()).html(
					'' + pageTotal.toFixed(2).replace('.', ',').replace(/(\d)(?=(\d{3})+(?!\d))/g, '$1.') + '<br/> (' + total.toFixed(2).replace('.', ',').replace(/(\d)(?=(\d{3})+(?!\d))/g, '$1.') + ')',
				);

			},

			//search: { caseInsensitive : true },

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
				{ data: 'balance' },
				{ data: 'sessionName' },
				{ data: 'branchName' },
				{ data: 'officeName' },
				{ data: 'recordDate' },
				{ data: 'id', responsivePriority: -1 },
			],
			columnDefs: [
				{
					targets: 3,
					render: $.fn.dataTable.render.number('.', ',', 2, ''),
					//render: function (data, type, full, meta) {
					//	return data.toFixed(2);
					//},
				},
				{
					targets: 4,
					render: $.fn.dataTable.render.number('.', ',', 2, ''),
					//render: function (data, type, full, meta) {
					//	return data.toFixed(2);
					//},
				},
				{
					targets: 5,
					render: $.fn.dataTable.render.number('.', ',', 2, ''),
					//render: function (data, type, full, meta) {
					//	return data.toFixed(2);
					//},
				},
				{
					targets: 8,
					visible: false,
				},
				{
					targets: 9,
					type: 'datetime',
					render: function (data, type, full, meta) {
						return moment(data).format("YYYY-MM-DD");
					},
				},
				{
					targets: 10,
					autoHide: false,
					orderable: false,
					render: function (data, type, full, meta) {
						return '\
							<a class="btn btn-sm btn-clean btn-icon mr-2" title="Duzenle" href="/Driver/GetDriverByIdWithDetails/'+ data+ '">\
									<span class="svg-icon svg-icon-md">\
										<svg xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" width="24px" height="24px" viewBox="0 0 24 24" version="1.1">\
											<g stroke="none" stroke-width="1" fill="none" fill-rule="evenodd">\
												<rect x="0" y="0" width="24" height="24" />\
												<path d="M8,17.9148182 L8,5.96685884 C8,5.56391781 8.16211443,5.17792052 8.44982609,4.89581508 L10.965708,2.42895648 C11.5426798,1.86322723 12.4640974,1.85620921 13.0496196,2.41308426 L15.5337377,4.77566479 C15.8314604,5.0588212 16,5.45170806 16,5.86258077 L16,17.9148182 C16,18.7432453 15.3284271,19.4148182 14.5,19.4148182 L9.5,19.4148182 C8.67157288,19.4148182 8,18.7432453 8,17.9148182 Z" fill="#000000" fill-rule="nonzero" \ transform="translate(12.000000, 10.707409) rotate(-135.000000) translate(-12.000000, -10.707409) " />\
												<rect fill="#000000" opacity="0.3" x="5" y="20" width="15" height="2" rx="1" />\
											</g>\
										</svg>\
									</span>\
							</a >\
							<a href="javascript:;" class="btn btn-sm btn-clean btn-icon" title="Sil" onclick="js_deleteDriverByIdQ('+ data + ')">\
								<span class="svg-icon svg-icon-md">\
									<svg xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" width="24px" height="24px" viewBox="0 0 24 24" version="1.1">\
										<g stroke="none" stroke-width="1" fill="none" fill-rule="evenodd">\
											<rect x="0" y="0" width="24" height="24"/>\
											<path d="M6,8 L6,20.5 C6,21.3284271 6.67157288,22 7.5,22 L16.5,22 C17.3284271,22 18,21.3284271 18,20.5 L18,8 L6,8 Z" fill="#000000" fill-rule="nonzero"/>\
											<path d="M14,4.5 L14,4 C14,3.44771525 13.5522847,3 13,3 L11,3 C10.4477153,3 10,3.44771525 10,4 L10,4.5 L5.5,4.5 C5.22385763,4.5 5,4.72385763 5,5 L5,5.5 C5,5.77614237 5.22385763,6 5.5,6 L18.5,6 C18.7761424,6 19,5.77614237 19,5.5 L19,5 C19,4.72385763 18.7761424,4.5 18.5,4.5 L14,4.5 Z" fill="#000000" opacity="0.3"/>\
										</g>\
									</svg>\
								</span>\
							</a>\
							<a href="javascript:;" class="btn btn-sm btn-clean btn-icon" title="Tahsilat Listesi" onclick="js_getAllCollectionDetailsByDriverInformationId('+ data + ')">\
								<span class="svg-icon svg-icon-md">\
											<svg xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" width="24px" height="24px" viewBox="0 0 24 24" version="1.1">\
												<g stroke="none" stroke-width="1" fill="none" fill-rule="evenodd">\
													<rect x="0" y="0" width="24" height="24" />\
													<path d="M8,3 L8,3.5 C8,4.32842712 8.67157288,5 9.5,5 L14.5,5 C15.3284271,5 16,4.32842712 16,3.5 L16,3 L18,3 C19.1045695,3 20,3.8954305 20,5 L20,21 C20,22.1045695 19.1045695,23 18,23 L6,23 C4.8954305,23 4,22.1045695 4,21 L4,5 C4,3.8954305 4.8954305,3 6,3 L8,3 Z" fill="#000000" opacity="0.3" />\
													<path d="M11,2 C11,1.44771525 11.4477153,1 12,1 C12.5522847,1 13,1.44771525 13,2 L14.5,2 C14.7761424,2 15,2.22385763 15,2.5 L15,3.5 C15,3.77614237 14.7761424,4 14.5,4 L9.5,4 C9.22385763,4 9,3.77614237 9,3.5 L9,2.5 C9,2.22385763 9.22385763,2 9.5,2 L11,2 Z" fill="#000000" />\
													<rect fill="#000000" opacity="0.3" x="10" y="9" width="7" height="2" rx="1" />\
													<rect fill="#000000" opacity="0.3" x="7" y="9" width="2" height="2" rx="1" />\
													<rect fill="#000000" opacity="0.3" x="7" y="13" width="2" height="2" rx="1" />\
													<rect fill="#000000" opacity="0.3" x="10" y="13" width="7" height="2" rx="1" />\
													<rect fill="#000000" opacity="0.3" x="7" y="17" width="2" height="2" rx="1" />\
													<rect fill="#000000" opacity="0.3" x="10" y="17" width="7" height="2" rx="1" />\
												</g>\
										 </svg>\
							   </span >\
							</a>\
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

		$('#search_driverInformationSessionName').on('change', function (e) {
			e.preventDefault();
			table.column(6).search(($(this).val() && $(this).val() != 'Hepsi') ? $(this).val().toUpperCase() : '', false, false);
			table.table().draw();
		});

		$('#search_driverInformationBranchName').on('change', function (e) {
			e.preventDefault();
			table.column(7).search(($(this).val() && $(this).val() != 'Hepsi') ? $(this).val().toUpperCase() : '', false, false);
			table.table().draw();
		});

	};

	return {

		//main function to initiate the module
		init: function () {
			initTableDriverInformations();
		},

	};

}();

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
							search: 'applied'
						},
						columns: [0, 1, 2, 3, 4],
						format: {
							body: function (data, row, column, node) {
								data = $('<p>' + data + '</p>').text();
								return $.isNumeric(data.replace('.', '').replace(',', '.')) ? data.replace('.', '').replace(',', '.') : data;
							}
						}
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

				// Total over all pages filtered
				var total = api.column(column, { search: 'applied', page: 'all' }).data().reduce(function (a, b) {
					return intVal(a) + intVal(b);
				}, 0);

				// Total over this page
				var pageTotal = api.column(column, { page: 'current' }).data().reduce(function (a, b) {
					return intVal(a) + intVal(b);
				}, 0);

				// Update footer
				$(api.column(column).footer()).html(
					'' + pageTotal.toFixed(2).replace('.', ',').replace(/(\d)(?=(\d{3})+(?!\d))/g, '$1.') + '<br/> (' + total.toFixed(2).replace('.', ',').replace(/(\d)(?=(\d{3})+(?!\d))/g, '$1.') + ' Toplam)',
				);

				column = 3;
				api = this.api(), data;

				// Remove the formatting to get integer data for summation
				var intVal = function (i) {
					return typeof i === 'string' ? i.replace(/[\$,]/g, '') * 1 : typeof i === 'number' ? i : 0;
				};

				// Total over all pages filtered
				var total = api.column(column, { search: 'applied', page: 'all' }).data().reduce(function (a, b) {
					return intVal(a) + intVal(b);
				}, 0);

				// Total over this page
				var pageTotal = api.column(column, { page: 'current' }).data().reduce(function (a, b) {
					return intVal(a) + intVal(b);
				}, 0);

				// Update footer
				$(api.column(column).footer()).html(
					'' + pageTotal.toFixed(2).replace('.', ',').replace(/(\d)(?=(\d{3})+(?!\d))/g, '$1.') + '<br/> (' + total.toFixed(2).replace('.', ',').replace(/(\d)(?=(\d{3})+(?!\d))/g, '$1.') + ' Toplam)',
				);

				column = 4;
				api = this.api(), data;

				// Remove the formatting to get integer data for summation
				var intVal = function (i) {
					return typeof i === 'string' ? i.replace(/[\$,]/g, '') * 1 : typeof i === 'number' ? i : 0;
				};

				// Total over all pages filtered
				var total = api.column(column, { search: 'applied', page: 'all' }).data().reduce(function (a, b) {
					return intVal(a) + intVal(b);
				}, 0);

				// Total over this page
				var pageTotal = api.column(column, { page: 'current' }).data().reduce(function (a, b) {
					return intVal(a) + intVal(b);
				}, 0);

				// Update footer
				$(api.column(column).footer()).html(
					'' + pageTotal.toFixed(2).replace('.', ',').replace(/(\d)(?=(\d{3})+(?!\d))/g, '$1.') + '<br/> (' + total.toFixed(2).replace('.', ',').replace(/(\d)(?=(\d{3})+(?!\d))/g, '$1.') + ' Toplam)',
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
					render: $.fn.dataTable.render.number('.', ',', 2, ''),
					//render: function (data, type, full, meta) {
					//	return data.toFixed(2);
					//},
				},
				{
					targets: 3,
					render: $.fn.dataTable.render.number('.', ',', 2, ''),
					//render: function (data, type, full, meta) {
					//	return data.toFixed(2);
					//},
				},
				{
					targets: 4,
					render: $.fn.dataTable.render.number('.', ',', 2, ''),
					//render: function (data, type, full, meta) {
					//	return data.toFixed(2);
					//},
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
							search: 'applied'
						},
						columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11],
						format: {
							body: function (data, row, column, node) {
								data = $('<p>' + data + '</p>').text();
								return $.isNumeric(data.replace('.', '').replace(',', '.')) ? data.replace('.', '').replace(',', '.') : data;
							}
						}
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

				// Total over all pages filtered
				var total = api.column(column, { search: 'applied', page: 'all' }).data().reduce(function (a, b) {
					return intVal(a) + intVal(b);
				}, 0);

				// Total over this page
				var pageTotal = api.column(column, { page: 'current' }).data().reduce(function (a, b) {
					return intVal(a) + intVal(b);
				}, 0);

				// Update footer
				$(api.column(column).footer()).html(
					'' + pageTotal.toFixed(2).replace('.', ',').replace(/(\d)(?=(\d{3})+(?!\d))/g, '$1.') + '<br/> (' + total.toFixed(2).replace('.', ',').replace(/(\d)(?=(\d{3})+(?!\d))/g, '$1.') + ' Toplam)',
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
					render: $.fn.dataTable.render.number('.', ',', 2, ''),
					//render: function (data, type, full, meta) {						
					//	return data.toFixed(2);
					//},
				},
				{
					targets: 11,
					render: $.fn.dataTable.render.number('.', ',', 2, ''),
					//render: function (data, type, full, meta) {
					//	return data.toFixed(2);
					//},
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
							search: 'applied'
						},
						columns: [0, 1, 2, 3, 4, 5, 6, 7, 8],
						format: {
							body: function (data, row, column, node) {
								data = $('<p>' + data + '</p>').text();
								return $.isNumeric(data.replace('.', '').replace(',', '.')) ? data.replace('.', '').replace(',', '.') : data;
							}
						}
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

				// Total over all pages filtered
				var total = api.column(column, { search: 'applied', page: 'all' }).data().reduce(function (a, b) {
					return intVal(a) + intVal(b);
				}, 0);

				// Total over this page
				var pageTotal = api.column(column, { page: 'current' }).data().reduce(function (a, b) {
					return intVal(a) + intVal(b);
				}, 0);

				// Update footer
				$(api.column(column).footer()).html(
					'' + pageTotal.toFixed(2).replace('.', ',').replace(/(\d)(?=(\d{3})+(?!\d))/g, '$1.') + '<br/> (' + total.toFixed(2).replace('.', ',').replace(/(\d)(?=(\d{3})+(?!\d))/g, '$1.') + ' Toplam)',
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
					render: $.fn.dataTable.render.number('.', ',', 2, ''),
					//render: function (data, type, full, meta) {
					//	return data.toFixed(2);
					//},
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
							search: 'applied'
						},
						columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13],
						format: {
							body: function (data, row, column, node) {
								data = $('<p>' + data + '</p>').text();
								return $.isNumeric(data.replace('.', '').replace(',', '.')) ? data.replace('.', '').replace(',', '.') : data;
							}
						}
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
				var column = 9;
				var api = this.api(), data;

				// Remove the formatting to get integer data for summation
				var intVal = function (i) {
					return typeof i === 'string' ? i.replace(/[\$,]/g, '') * 1 : typeof i === 'number' ? i : 0;
				};

				// Total over all pages filtered
				var total = api.column(column, { search: 'applied', page: 'all' }).data().reduce(function (a, b) {
					return intVal(a) + intVal(b);
				}, 0);

				// Total over this page
				var pageTotal = api.column(column, { page: 'current' }).data().reduce(function (a, b) {
					return intVal(a) + intVal(b);
				}, 0);

				// Update footer
				$(api.column(column).footer()).html(
					'' + pageTotal.toFixed(2).replace('.', ',').replace(/(\d)(?=(\d{3})+(?!\d))/g, '$1.') + '<br/> (' + total.toFixed(2).replace('.', ',').replace(/(\d)(?=(\d{3})+(?!\d))/g, '$1.') + ' Toplam)',
				);

				column = 10;
				api = this.api(), data;

				// Remove the formatting to get integer data for summation
				var intVal = function (i) {
					return typeof i === 'string' ? i.replace(/[\$,]/g, '') * 1 : typeof i === 'number' ? i : 0;
				};

				// Total over all pages filtered
				var total = api.column(column, { search: 'applied', page: 'all' }).data().reduce(function (a, b) {
					return intVal(a) + intVal(b);
				}, 0);

				// Total over this page
				var pageTotal = api.column(column, { page: 'current' }).data().reduce(function (a, b) {
					return intVal(a) + intVal(b);
				}, 0);

				// Update footer
				$(api.column(column).footer()).html(
					'' + pageTotal.toFixed(2).replace('.', ',').replace(/(\d)(?=(\d{3})+(?!\d))/g, '$1.') + '<br/> (' + total.toFixed(2).replace('.', ',').replace(/(\d)(?=(\d{3})+(?!\d))/g, '$1.') + ' Toplam Borç)',
				);
				
			},

			//drawCallback: function () {
			//	var sum = $('#datatable_CashReport1').DataTable().column(4).data().sum();
			//	$('#total').html(sum);
			//},

			order: [],			

			columns: [
				{ data: 'nameSurname', responsivePriority: 0 },
				{ data: 'identityNo' },
				{ data: 'phone1' },
				{ data: 'courseFee' },
				{ data: 'courseFeePlus' },
				{ data: 'collectionDefinitionTypeName' },
				{ data: 'paymentDate' },
				{ data: 'paymentDateYear' },
				{ data: 'paymentDateMonthName' },
				{ data: 'amount' },
				{ data: 'debitinMonth', responsivePriority: 1 },
				{ data: 'sessionName' },
				{ data: 'branchName' },
				{ data: 'officeName' },
				{ data: 'driverInformationId', responsivePriority: -1 },
			],
			columnDefs: [
				{
					targets: 3,
					render: $.fn.dataTable.render.number('.', ',', 2, ''),
					//render: function (data, type, full, meta) {
					//	return data.toFixed(2);
					//},
				},
				{
					targets: 4,
					render: $.fn.dataTable.render.number('.', ',', 2, ''),
					//render: function (data, type, full, meta) {
					//	return data.toFixed(2);
					//},
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
					type : 'string',
					render: function (data, type, full, meta) {
						return data.toString();
					},
				},
				{
					targets: 9,
					render: $.fn.dataTable.render.number('.', ',', 2, ''),
					//render: function (data, type, full, meta) {
					//	return data.toFixed(2);
					//},
				},
				{
					targets: 10,
					autoHide: false,
					render: $.fn.dataTable.render.number('.', ',', 2, ''),
					//render: function (data, type, full, meta) {
					//	return data.toFixed(2);
					//},
				},
				{					
					targets: 14,
					autoHide: false,
					orderable: false,
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
	DatatablesButtonsDriverInformations.init();
	DatatablesButtonsCashReport1.init();
	DatatablesButtonsCashReport1DetailCollection.init();
	DatatablesButtonsCashReport1DetailExpense.init();
	DatatablesButtonsListOfDueCoursePaymentsReport.init();
	
});

