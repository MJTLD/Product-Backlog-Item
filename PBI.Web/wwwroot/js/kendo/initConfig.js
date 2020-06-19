kendo.pdf.defineFont({
    "DejaVu Sans": "https://kendo.cdn.telerik.com/2016.2.607/styles/fonts/DejaVu/DejaVuSans.ttf",
    "DejaVu Sans|Bold": "https://kendo.cdn.telerik.com/2016.2.607/styles/fonts/DejaVu/DejaVuSans-Bold.ttf",
    "DejaVu Sans|Bold|Italic": "https://kendo.cdn.telerik.com/2016.2.607/styles/fonts/DejaVu/DejaVuSans-Oblique.ttf",
    "DejaVu Sans|Italic": "https://kendo.cdn.telerik.com/2016.2.607/styles/fonts/DejaVu/DejaVuSans-Oblique.ttf",
    "WebComponentsIcons": "https://kendo.cdn.telerik.com/2017.1.223/styles/fonts/glyphs/WebComponentsIcons.ttf"
});

kendo.culture("fa-IR");

function popupEdit() {
    $("#report-grid").data("kendoGrid").options.editable.mode = "popup";
}
function inlineEdit() {
    $("#report-grid").data("kendoGrid").options.editable.mode = "inline";
}

// اين اطلاعات براي تهيه خروجي سمت سرور مناسب هستند
function getCurrentGridFilters() {
    var dataSource = $("#report-grid").data("kendoGrid").dataSource;
    var gridState = {
        page: dataSource.page(),
        pageSize: dataSource.pageSize(),
        sort: dataSource.sort(),
        group: dataSource.group(),
        filter: dataSource.filter()
    };
    console.log(gridState);
    return kendo.stringify(gridState);
}
