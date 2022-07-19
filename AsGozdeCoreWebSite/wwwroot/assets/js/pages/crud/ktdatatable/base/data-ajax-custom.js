"use strict";
// Class definition

var KTDatatableRemoteAjaxDemo = function() {
    // Private functions

    // basic demo
    var demo = function() {

        var datatable = $('#datatableAjax_DriverInformations').KTDatatable({
            // datasource definition
            data: {
                type: 'remote',
                source: {
                    read: {
                        url: window.location.href.replace('/Index', '').replace('/Driver/', '/Driver') + '/GetListOfDriverInformationByOfficeIdService',
                        // sample custom headers
                        headers: {'x-my-custom-header': 'some value', 'x-test-header': 'the value'},
                        map: function(raw) {
                            // sample data mapping
                            var dataSet = raw;
                            if (typeof raw.data !== 'undefined') {
                                dataSet = raw.data;
                            }
                            return dataSet;
                        },
                    },
                },
                pageSize: 10,
                serverPaging: false,
                serverFiltering: false,
                serverSorting: false,
                autoColumns: false,
                saveState: false,
            },

            // layout definition
            layout: {
                scroll: false,
                footer: false,
            },

            // column sorting
            sortable: true,

            pagination: true,

            search: {
                input: $('#datatableAjaxDriverInformations_search_query'),
                key: 'generalSearch'
            },

            // columns definition
            columns: [{
                field: 'nameSurname',
                title: 'Adi Soyadi',
            }, {
                field: 'identityNo',
                title: 'TC Kimlik No',
            },{
                field: 'phone1',
                title: 'Telefon 1',
            },{
                field: 'courseFee',
                title: 'Kurs Ucreti',
                type : 'string',
                textAlign: 'right',
                //sortCallback: function (data, sort, column) {
                //    var field = column['field'];
                //    return $(data).sort(function (a, b) {
                //        var aField = a[field];
                //        var bField = b[field];
                //        if (isNaN(parseFloat(aField)) && aField != null) {
                //            aField = Number(aField.replace(/[^0-9\.-]+/g, ''));
                //        }
                //        if (isNaN(parseFloat(bField)) && aField != null) {
                //            bField = Number(bField.replace(/[^0-9\.-]+/g, ''));
                //        }
                //        aField = parseFloat(aField);
                //        bField = parseFloat(bField);
                //        if (sort === 'asc') {
                //            return aField > bField ? 1 : aField < bField ? -1 : 0;
                //        } else {
                //            return aField < bField ? 1 : aField > bField ? -1 : 0;
                //        }
                //    });
                //},
                template: function (row) {
                    return row.courseFee.toFixed(2).toString().replace('.',',');
                },
            },{
                field: 'courseFeePlus',
                title: 'Ilave 4 Hak Kurs Ucreti',
                type: 'string',
                textAlign: 'right',
                //sortCallback: function (data, sort, column) {
                //    var field = column['field'];
                //    return $(data).sort(function (a, b) {
                //        var aField = a[field];
                //        var bField = b[field];
                //        if (isNaN(parseFloat(aField)) && aField != null) {
                //            aField = Number(aField.replace(/[^0-9\.-]+/g, ''));
                //        }
                //        if (isNaN(parseFloat(bField)) && aField != null) {
                //            bField = Number(bField.replace(/[^0-9\.-]+/g, ''));
                //        }
                //        aField = parseFloat(aField);
                //        bField = parseFloat(bField);
                //        if (sort === 'asc') {
                //            return aField > bField ? 1 : aField < bField ? -1 : 0;
                //        } else {
                //            return aField < bField ? 1 : aField > bField ? -1 : 0;
                //        }
                //    });
                //},
                template: function (row) {
                    return row.courseFeePlus.toFixed(2).toString().replace('.', ',');
                },
            },{
                field: 'balance',
                title: 'Kalan Borc',
                type: 'number',
                textAlign: 'right',
                //sortCallback: function (data, sort, column) {
                //    var field = column['field'];
                //    return $(data).sort(function (a, b) {
                //        var aField = a[field];
                //        var bField = b[field];
                //        if (isNaN(parseFloat(aField)) && aField != null) {
                //            aField = Number(aField.replace(/[^0-9\.-]+/g, ''));
                //        }
                //        if (isNaN(parseFloat(bField)) && aField != null) {
                //            bField = Number(bField.replace(/[^0-9\.-]+/g, ''));
                //        }
                //        aField = parseFloat(aField);
                //        bField = parseFloat(bField);
                //        if (sort === 'asc') {
                //            return aField > bField ? 1 : aField < bField ? -1 : 0;
                //        } else {
                //            return aField < bField ? 1 : aField > bField ? -1 : 0;
                //        }
                //    });
                //},
                template: function (row) {
                    return row.balance.toFixed(2).toString().replace('.', ',');
                },
            }, {
                field: 'sessionName',
                title: 'Donem',
                template: function (row) {
                    return row.sessionName + ' - ' + row.sessionYear + '-' + row.sessionSequence;
                },
            }, {
                field: 'branchName',
                title: 'Brans',
            }, {
                field: 'officeName',
                title: 'Sube',
            }, {
                field: 'id',
                title: 'Islem',
                sortable: false,
                autoHide: false,
                width: 125,
                template: function (row) {
                    return '\
                        <a class="btn btn-sm btn-clean btn-icon mr-2" title="Duzenle" href="/Driver/GetDriverByIdWithDetails/'+ row.id + '">\
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
                        <a href="javascript:;" class="btn btn-sm btn-clean btn-icon" title="Sil" onclick="js_deleteDriverByIdQ('+ row.id + ')">\
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
                        <a href="javascript:;" class="btn btn-sm btn-clean btn-icon" title="Tahsilat Listesi" onclick="js_getAllCollectionDetailsByDriverInformationId('+ row.id +')">\
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
            } ],
                        
            

        });

        $('#kt_datatable_search_type').on('change', function () {
            datatable.search($(this).val().toLowerCase(), 'Type');
        });

        $('#kt_datatable_search_donem').on('change', function () {
            datatable.search($(this).val().toLowerCase(), 'sessionName');
        });

        $('#kt_datatable_search_type, #kt_datatable_search_donem').selectpicker();
    };

    return {
        // public functions
        init: function() {
            demo();
        },
    };
}();

jQuery(document).ready(function() {
    KTDatatableRemoteAjaxDemo.init();
});
