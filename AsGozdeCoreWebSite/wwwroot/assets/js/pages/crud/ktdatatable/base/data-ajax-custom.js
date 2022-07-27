"use strict";
// Class definition

var KTDatatableRemoteAjaxDriverInformations = function() {
    // Private functions

    // basic demo
    var demo = function() {

        var datatable = $('#datatableAjax_DriverInformation').KTDatatable({
            // datasource definition
            data: {
                type: 'remote',
                source: {
                    read: {
                        url: window.location.href.replace('/Index', '').replace('/Driver/', '/Driver') + '/GetListOfDriverInformationByOfficeId',
                        // sample custom headers
                        //headers: {'x-my-custom-header': 'some value', 'x-test-header': 'the value'},
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
                input: $('#datatableAjaxDriverInformation_search_query'),
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
                //template: function (row) {
                //    return row.sessionName + ' - ' + row.sessionYear + '-' + row.sessionSequence;
                //},
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
                textAlign: 'center',
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

        
        $('#kt_datatable_search_driverInformationSessionName').on('change', function () {
            datatable.search($(this).val().toUpperCase(), 'sessionName');
        });

        $('#kt_datatable_search_driverInformationSessionName').selectpicker();
    };

    return {
        // public functions
        init: function() {
            demo();
        },
    };
}();

var KTDatatableRemoteAjaxDriverInformationSelects = function () {
    // Private functions

    // basic demo
    var demo = function () {

        var datatable = $('#datatableAjax_DriverInformationSelect').KTDatatable({
            // datasource definition
            data: {
                type: 'remote',
                source: {
                    read: {
                        url: window.location.protocol + '//' + window.location.hostname + ':' + window.location.port + '/Driver/GetListOfDriverInformationByOfficeId',
                        // sample custom headers
                        //headers: {'x-my-custom-header': 'some value', 'x-test-header': 'the value'},
                        map: function (raw) {
                            // sample data mapping
                            var dataSet = raw;
                            if (typeof raw.data !== 'undefined') {
                                dataSet = raw.data;
                            }
                            return dataSet;
                        },
                    },
                },
                pageSize: 5,
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
                input: $('#datatableAjaxDriverInformationSelect_search_query'),
                key: 'generalSearch'
            },

            // columns definition
            columns: [{
                field: 'id',
                title: 'Sec',
                sortable: false,
                autoHide: false,
                width: 50,
                textAlign: 'center',
                template: function (row) {
                    return '\
                        <button class="btn btn-sm btn-clean" title="Sec" onclick="js_addDriverById('+ row.id + ')">\
                            <i class="flaticon2-add" ></i > Sec\
                        </button >\
                    ';
                },
            }, {
                field: 'nameSurname',
                title: 'Adi Soyadi',
            }, {
                field: 'identityNo',
                title: 'TC Kimlik No',
            }, {
                field: 'phone1',
                title: 'Telefon 1',
            }, {
                field: 'sessionName',
                title: 'Donem',
            }, {
                field: 'branchName',
                title: 'Brans',
            }],



        });


        $('#kt_datatable_search_driverInformationSelectSessionName').on('change', function () {
            datatable.search($(this).val().toUpperCase(), 'sessionName');
        });

        $('#kt_datatable_search_driverInformationSelectSessionName').selectpicker();
    };

    return {
        // public functions
        init: function () {
            demo();
        },
    };
}();

var KTDatatableRemoteAjaxCollections = function () {
    // Private functions

    // basic demo
    var demo = function () {

        var datatable = $('#datatableAjax_Collection').KTDatatable({
            // datasource definition
            data: {
                type: 'remote',
                source: {
                    read: {
                        url: window.location.href.replace('/Index', '').replace('/Collection/', '/Collection') + '/GetListOfCollectionByOfficeId',
                        // sample custom headers
                        //headers: { 'x-my-custom-header': 'some value', 'x-test-header': 'the value' },
                        map: function (raw) {
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
                input: $('#datatableAjaxCollection_search_query'),
                key: 'generalSearch'
            },

            // columns definition
            columns: [{
                field: 'documentNo',
                title: 'Evrak Seri No',
            }, {
                field: 'collectionDate',
                title: 'Tarih',
                type: 'date',
                format:'DD/MM/YYYY',
            }, {
                field: 'nameSurname',
                title: 'Adi Soyadi',
            },{
                field: 'identityNo',
                title: 'TC Kimlik No',
            }, {
                field: 'phone1',
                title: 'Telefon 1',
            }, {
                field: 'totalAmount',
                title: 'Tutar',
                type: 'number',
                textAlign: 'right',
                template: function (row) {
                    return row.totalAmount.toFixed(2).toString().replace('.', ',');
                },
            }, {
                field: 'sessionName',
                title: 'Donem',
                //template: function (row) {
                //    return row.sessionName + ' - ' + row.sessionYear + '-' + row.sessionSequence;
                //},
            }, {
                field: 'officeName',
                title: 'Sube',
            }, {
                field: 'id',
                title: 'Islem',
                sortable: false,
                autoHide: false,
                width: 150,
                textAlign: 'center',
                template: function (row) {
                    return '\
                       <a class="btn btn-sm btn-clean btn-icon mr-2" title = "Duzenle" href="/Collection/GetCollectionByIdWithDetails/'+ row.id +'" >\
                            <span class="svg-icon svg-icon-md">\
                                        <svg xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" width="24px" height="24px" viewBox="0 0 24 24" version="1.1">\
                                            <g stroke="none" stroke-width="1" fill="none" fill-rule="evenodd">\
                                                <rect x="0" y="0" width="24" height="24" />\
                                                <path d="M8,17.9148182 L8,5.96685884 C8,5.56391781 8.16211443,5.17792052 8.44982609,4.89581508 L10.965708,2.42895648 C11.5426798,1.86322723 12.4640974,1.85620921 13.0496196,2.41308426 L15.5337377,4.77566479 C15.8314604,5.0588212 16,5.45170806 16,5.86258077 L16,17.9148182 C16,18.7432453 15.3284271,19.4148182 14.5,19.4148182 L9.5,19.4148182 C8.67157288,19.4148182 8,18.7432453 8,17.9148182 Z" fill="#000000" fill-rule="nonzero" \ transform="translate(12.000000, 10.707409) rotate(-135.000000) translate(-12.000000, -10.707409) " />\
                                                <rect fill="#000000" opacity="0.3" x="5" y="20" width="15" height="2" rx="1" />\
                                            </g>\
                                        </svg>\
                           </span>\
                       </a>\
                       <a href="javascript:;" class="btn btn-sm btn-clean btn-icon" title="Sil" onclick="js_deleteCollectionByIdQ('+ row.id + ')">\
                         <span class="svg-icon svg-icon-md">\
                                        <svg xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" width="24px" height="24px" viewBox="0 0 24 24" version="1.1">\
                                            <g stroke="none" stroke-width="1" fill="none" fill-rule="evenodd">\
                                                <rect x="0" y="0" width="24" height="24" />\
                                                <path d="M6,8 L6,20.5 C6,21.3284271 6.67157288,22 7.5,22 L16.5,22 C17.3284271,22 18,21.3284271 18,20.5 L18,8 L6,8 Z" fill="#000000" fill-rule="nonzero" />\
                                                <path d="M14,4.5 L14,4 C14,3.44771525 13.5522847,3 13,3 L11,3 C10.4477153,3 10,3.44771525 10,4 L10,4.5 L5.5,4.5 C5.22385763,4.5 5,4.72385763 5,5 L5,5.5 C5,5.77614237 5.22385763,6 5.5,6 L18.5,6 C18.7761424,6 19,5.77614237 19,5.5 L19,5 C19,4.72385763 18.7761424,4.5 18.5,4.5 L14,4.5 Z" fill="#000000" opacity="0.3" />\
                                            </g>\
                                        </svg>\
                        </span>\
                      </a>\
                    <a href="javascript:;" class="btn btn-sm btn-clean btn-icon" title="Yazdir" onclick="js_printCollection('+ row.id + ')">\
                            <span class="svg-icon svg-icon-md" >\
                                <svg xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" width="24px" height="24px" viewBox="0 0 24 24" version="1.1">\
                                    <g stroke="none" stroke-width="1" fill="none" fill-rule="evenodd">\
                                        <rect x="0" y="0" width="24" height="24" />\
                                        <path d="M16,17 L16,21 C16,21.5522847 15.5522847,22 15,22 L9,22 C8.44771525,22 8,21.5522847 8,21 L8,17 L5,17 C3.8954305,17 3,16.1045695 3,15 L3,8 C3,6.8954305 3.8954305,6 5,6 L19,6 C20.1045695,6 21,6.8954305 21,8 L21,15 C21,16.1045695 20.1045695,17 19,17 L16,17 Z M17.5,11 C18.3284271,11 19,10.3284271 19,9.5 C19,8.67157288 18.3284271,8 17.5,8 C16.6715729,8 16,8.67157288 16,9.5 C16,10.3284271 16.6715729,11 17.5,11 Z M10,14 L10,20 L14,20 L14,14 L10,14 Z" fill="#000000" />\
                                        <rect fill="#000000" opacity="0.3" x="8" y="2" width="8" height="2" rx="1" />\
                                    </g>\
                                </svg>\
                            </span >\
                       </a >\
                    <a class="btn btn-sm btn-clean btn-icon" title="Surucu Adayi Bilgileri" href="/Driver/GetDriverByIdWithDetails/'+ row.driverInformationId + '">\
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
            }],
        });


        $('#kt_datatable_search_collectionSessionName').on('change', function () {
            datatable.search($(this).val().toUpperCase(), 'sessionName');
        });

        $('#kt_datatable_search_collectionSessionName').selectpicker();
    };

    return {
        // public functions
        init: function () {
            demo();
        },
    };
}();

var KTDatatableRemoteAjaxListOfDueCoursePayments = function () {
    // Private functions

    // basic demo
    var demo = function () {

        var datatable = $('#datatableAjax_ListOfDueCoursePayment').KTDatatable({
            // datasource definition
            data: {
                type: 'remote',
                source: {
                    read: {
                        url: window.location.href.replace('/ListOfDueCoursePayments', '').replace('/Report/', '/Report') + '/GetListOfDueCoursePayments',
                        // sample custom headers
                        //headers: { 'x-my-custom-header': 'some value', 'x-test-header': 'the value' },
                        map: function (raw) {
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
                input: $('#datatableAjaxListOfDueCoursePayment_search_query'),
                key: 'generalSearch'
            },

            // columns definition
            columns: [
            {
                field: 'nameSurname',
                title: 'Adi Soyadi',
            }, {
                field: 'identityNo',
                title: 'TC Kimlik No',
            }, {
                field: 'phone1',
                title: 'Telefon 1',
            }, {
                field: 'courseFee',
                title: 'Kurs Ucreti',
                type: 'number',
                textAlign: 'right',
                template: function (row) {
                    return row.courseFee.toFixed(2).toString().replace('.', ',');
                },
            }, {
                field: 'courseFeePlus',
                title: 'Ilave 4 Hak Kurs Ucreti',
                type: 'number',
                textAlign: 'right',
                template: function (row) {
                    return row.courseFeePlus.toFixed(2).toString().replace('.', ',');
                },
            }, {
                field: 'collectionDefinitionTypeName',
                title: 'Odeme Plani Adi',
            }, {
                field: 'paymentDate',
                title: 'Odeme Plani Tarihi',
                type: 'date',
                format: 'DD/MM/YYYY',
            }, {
                field: 'amount',
                title: 'Odeme Plani Tutari',
                type: 'number',
                textAlign: 'right',
                template: function (row) {
                    return row.amount.toFixed(2).toString().replace('.', ',');
                },
            }, {
                field: 'debitinMonth',
                title: 'Kalan Borc',
                type: 'number',
                textAlign: 'right',
                template: function (row) {
                    return row.debitinMonth.toFixed(2).toString().replace('.', ',');
                },
            }, {
                field: 'sessionName',
                title: 'Donem',
                //template: function (row) {
                //    return row.sessionName + ' - ' + row.sessionYear + '-' + row.sessionSequence;
                //},
            }, {
                field: 'branchName',
                title: 'Brans',
            }, {
                field: 'officeName',
                title: 'Sube',
            }, {
                field: 'driverPaymentPlanId',
                title: 'Islem',
                sortable: false,
                autoHide: false,
                width: 75,
                textAlign: 'center',
                template: function (row) {
                    return '\
                    <a class="btn btn-sm btn-clean btn-icon" title="Surucu Adayi Bilgileri" href="/Driver/GetDriverByIdWithDetails/'+ row.driverInformationId + '">\
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
            }],
        });


        $('#kt_datatable_search_listOfDueCoursePaymentSessionName').on('change', function () {
            datatable.search($(this).val().toUpperCase(), 'sessionName');
        });

        $('#kt_datatable_search_listOfDueCoursePaymentSessionName').selectpicker();        
    };

    return {
        // public functions
        init: function () {
            demo();
        },
    };
}();

jQuery(document).ready(function() {
    KTDatatableRemoteAjaxDriverInformations.init();
    KTDatatableRemoteAjaxDriverInformationSelects.init();
    KTDatatableRemoteAjaxCollections.init();
    KTDatatableRemoteAjaxListOfDueCoursePayments.init();
});
