var GridHyperlinkOptionsExtension = (function () {
    var Model = DevExpress.Dashboard.Model;
    var Designer = DevExpress.Dashboard.Designer;

    // 1. Model
    var TargetProperty = {
        ownerType: Model.GridItem,
        propertyName: 'Target',
        defaultValue: '_blank',
        valueType: 'string'
    };

    var CustomJSProperty = {
        ownerType: Model.GridItem,
        propertyName: 'Id',
        defaultValue: '1',
        valueType: 'int'
    };

    Model.registerCustomProperty(TargetProperty);
    Model.registerCustomProperty(CustomJSProperty);

    // 2. Viewer
    function onItemWidgetOptionsPrepared(args) {
        if (args.dashboardItem instanceof Model.GridItem) {
            args.options.onCellPrepared = function (e) {
                if (e.column.displayMode == 'Hyperlink' && e.rowType == 'data') {
                    var a = e.cellElement.find('a');
                    var customJS = args.dashboardItem.customProperties.getValue(CustomJSProperty.propertyName);

                    if (customJS) {
                        var uriKey = Object.keys(e.data).filter(key => key.indexOf(e.column.dataField) == 0);
                        /*a.attr('href', 'javascript:' + customJS.replace('{0}', e.data[uriKey]));*/
                        a.attr('href', window.location.protocol + '//' + window.location.hostname + ':' + window.location.port + '/Expense/GetExpenseByIdWithDetails?id=' + e.data[uriKey]);
                    }

                    /*a.attr('target', window.location.protocol + '//' + window.location.hostname + ':' + window.location.port + '/Expense/GetExpenseByIdWithDetails?id=' + e.data[uriKey]);*/
                    /*a.attr('target', args.dashboardItem.customProperties.getValue(TargetProperty.propertyName));*/
                }
            };
        }
    };

    // 3. Designer
    function onCustomizeSections(args) {
        var item = args.dashboardItem;
        if (item instanceof Model.GridItem) {
            args.addSection({
                title: "Hyperlink Options (Custom)",
                items: [
                    {
                        dataField: TargetProperty.propertyName,
                        label: {
                            text: "Target"
                        },
                        template: Designer.FormItemTemplates.buttonGroup,
                        editorOptions: {
                            keyExpr: "value",
                            items: [{
                                value: "_blank",
                                text: "New window"
                            }, {
                                value: "_self",
                                text: "Same window"
                            }]
                        }
                    },
                    {
                        dataField: CustomJSProperty.propertyName,
                        editorType: "dxTextBox",
                        label: {
                            text: "Custom JavaScript Code"
                        },
                        editorOptions: {
                            placeholder: "alert('{0}')"
                        }
                    }
                ]
            });
        }
    };

    // 4. Event Subscription
    function GridHyperlinkOptionsExtension(dashboardControl) {
        this.name = "GridHyperlinkOptions",
            this.start = function () {
                var viewerApiExtension = dashboardControl.findExtension('viewer-api');
                if (viewerApiExtension) {
                    viewerApiExtension.on('itemWidgetOptionsPrepared', onItemWidgetOptionsPrepared);
                }
                var optionsPanelExtension = dashboardControl.findExtension("item-options-panel");
                if (optionsPanelExtension) {
                    optionsPanelExtension.on('customizeSections', onCustomizeSections);
                }
            },
            this.stop = function () {
                var viewerApiExtension = dashboardControl.findExtension('viewer-api');
                if (viewerApiExtension) {
                    viewerApiExtension.off('itemWidgetOptionsPrepared', onItemWidgetOptionsPrepared);
                }
                var optionsPanelExtension = dashboardControl.findExtension("item-options-panel");
                if (optionsPanelExtension) {
                    optionsPanelExtension.off('customizeSections', onCustomizeSections);
                }
            }
    }
    return GridHyperlinkOptionsExtension;
}());