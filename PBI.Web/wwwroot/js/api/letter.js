$(function () {
    var lettersDataSource = new kendo.data.DataSource({
        transport: {
            read: {
                url: '/Letter/GetAllData/',
                dataType: "json",
                contentType: 'application/json; charset=utf-8',
                type: 'GET'
            },
            parameterMap: function (options) {
                return kendo.stringify(options);
            }
        },
        schema: {
            data: "data",
            total: "total",
            model: {
                id: "letterId",
                fields: {
                    letterId: { type: "number", editable: false},
                    LetterNum: { type: "string", validation: { required: true } },
                    LetterDate: { type: "date", validation: { required: true } },
                    Subject: { type: "string", validation: { required: true } },
                    Receptor: { type: "string", validation: { required: true } },
                    LetterText: { type: "string", validation: { required: true } },
                }
            }
        },
        batch: false,
        error: function (e) {
            console.log(e);
        },
        pageSize: 10,
        type: "odata",
        sort: { field: "letterId", dir: "asc" },
        serverPaging: true,
        serverFiltering: true,
        serverSorting: true,
    });
    
    console.log(lettersDataSource);
    
    $("#report-grid").kendoGrid({
        dataSource: lettersDataSource,
        autoBind: true,
        scrollable: false,
        allowCopy: true,
        pageable: {
            previousNext: true, // default true
            numeric: true, // default true
            buttonCount: 5, // default 10
            refresh: true, // default false
            input: true, // default false
            //pageSizes: true, // default false
            pageSizes: [5, 10, 15, 20, 25], //array of page size choices for user
            info: true // show a label with current paging information in it
        },
        sortable: true,
        filterable: true,
        reorderable: true,  
        columnMenu: true,
        selectable: "single",
        groupable: true, // allows the user to alter what field the grid is grouped by
        editable: {
            confirmation: "آيا مايل به حذف رديف انتخابي هستيد؟",
            destroy: true, // whether or not to delete item when button is clicked
            mode: "inline", // options are "incell", "inline", and "popup"
            //template: kendo.template($("#popupEditorTemplate").html()), // template to use for pop-up editing
            update: false, // switch item to edit mode when clicked?
            window: {
                title: "ویرایش"   // Localization for Edit in the popup window
            }
        },
        //navigatable: true,
        columns: [
            {
                title: "#",
                template: "<span class='row-number'></span>",
                width: 30
            },
            {
                field: "letterId", title: "شماره ",hidden:true
            },
            {
                field: "letterNum", title: "شماره نامه"
            },
            {
                field: "letterDate", title: "تاریخ نامه",
                template: "#=moment(letterDate).format('jYYYY/jMM/jDD')#"
            },
            {
                field: "subject", title: "موضوع"
            },
            {
                field: "receptor", title: "گیرنده"
            },
            {
                field: "letterText", title: "متن نامه"
            },
            {
                command: [
                    { text: "حذف", click: deleteRow },
                    { text: "ویرایش", click: updateDetails }
                ],
                title: "&nbsp;", width: "200px"
            }
        ],
        dataBound: function() {
            var rows = this.items();
            $(rows).each(function() {
                var index = $(this).index() +
                    1 +
                    ($("#report-grid").data("kendoGrid").dataSource.pageSize() *
                        ($("#report-grid").data("kendoGrid").dataSource.page() - 1));
                var rowLabel = $(this).find(".row-number");
                $(rowLabel).html(index);
            });
        },
        toolbar:
            [{ name: "excel", text: "خروجی اکسل" },
                { name: "pdf", text: "خروجی PDF" }],
        excel: {
            fileName: "Export.xlsx",
            allPages: true,
            filterable: true
        },
        pdf: {
            allPages: true,
            avoidLinks: true,
            paperSize: "A4",
            margin: { top: "2cm", left: "1cm", right: "1cm", bottom: "1cm" },
            landscape: true,
            repeatHeaders: true,
            template: $("#page-template-pdf").html(),
            scale: 0.8
        }
    });
});

const updateDetails = e => {
    e.preventDefault();
    //var entityGrid = $("#report-grid").data("kendoGrid");
    var grid = $("#report-grid").data("kendoGrid");
    var selectedItem = grid.dataItem(grid.select());
    console.log(selectedItem);
}

const deleteRow = e => {
    e.preventDefault();
    
}