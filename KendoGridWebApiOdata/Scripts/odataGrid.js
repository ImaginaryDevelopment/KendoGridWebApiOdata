$(function () {
    var dataSource = new kendo.data.DataSource({
        type: "odata",
        transport: {
            read: {
                url: "/api/Cats?$expand=Mate&$select=*,Mate/Name",
                dataType: "json"
            },
        },
        schema: {
            data: function (data) {
                return data["value"];
            },
            total: function (data) {
                return data["odata.count"];
            },
            model: {
                fields: {
                    Id: { type: "number" },
                    Name: { type: "string" },
                    Color: { type: "string" },
                    Mate:{type:"object"}
                }
            }
        },
        pageSize: 10,
        serverPaging: true,
        serverFiltering: true,
        serverSorting: true
    });

    $("#grid").kendoGrid({
        dataSource: dataSource,
        filterable: true,
        sortable: true,
        pageable: true,
        columns: [
            { field: "Id" },
            { field: "Name" },
            { field: "Color" },
            {field:"Mate? Mate.Name:''",title:"Mate Name"}
        ]
    });
});