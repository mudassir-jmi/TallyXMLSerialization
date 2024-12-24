
<div id="gridContainer">
    @(Html.DevExtreme().DataGrid<SampleOrder>()
        .ID("gridContainer")
        .ShowBorders(true)
        .FilterPanel(f => f.Visible(true).FilterEnabled(true))
        .DataSource(d => d.WebApi()
            .RouteName("SampleData")
            .Controller("SampleData")
            .Key("OrderID")

            .LoadAction("Get")
            .InsertAction("Create")
            .UpdateAction("Update")
            .DeleteAction("Delete")
        )
        .Columns(columns => {
            columns.AddFor(m => m.OrderID);
            columns.AddFor(m => m.OrderDate);
            columns.AddFor(m => m.CustomerName);
            columns.AddFor(m => m.ShipCountry);
            columns.AddFor(m => m.ShipCity);
            columns.AddFor(m => m.Price);
            columns.AddFor(m => m.TenantID);
            columns.AddFor(m => m.CompanyID);
        })
        .Paging(paging => paging.PageSize(10))
        .Pager(pager =>
        {
            pager.Visible(true);
            pager.DisplayMode(GridPagerDisplayMode.Full);
            pager.ShowPageSizeSelector(true);
            pager.AllowedPageSizes(new JS("[5, 10, 'all']"));
            pager.ShowInfo(true);
            pager.ShowNavigationButtons(true);
        })
        .FilterRow(f => f.Visible(true))
        .HeaderFilter(f => f.Visible(false))
        .GroupPanel(p => p.Visible(true))
        .Grouping(g => g.AutoExpandAll(false))
        .RemoteOperations(true)
        .SearchPanel(sp => sp.Visible(false).HighlightCaseSensitive(false))
        .RemoteOperations(r => r.Filtering(true))
        .Editing(editing =>
            editing.Mode(GridEditMode.Popup)
                 .AllowUpdating(true)
                 .AllowAdding(true)
                 .AllowDeleting(true)
                .Popup(p => p
                    .Title("Order Info")
                    .ShowTitle(true)
                    .Width(700)
                    .Height(525)
                )
                .Form(f => f.Items(items =>
                {
                    items.AddGroup()
                        .ColCount(2)
                        .ColSpan(2)
                        .Items(groupItems =>
                        {
                            groupItems.AddSimpleFor(m => m.OrderID);
                            groupItems.AddSimpleFor(m => m.OrderDate);
                            groupItems.AddSimpleFor(m => m.CustomerName);
                            groupItems.AddSimpleFor(m => m.ShipCountry);
                            groupItems.AddSimpleFor(m => m.ShipCity);
                            groupItems.AddSimpleFor(m => m.Price);
                        });
                })
            )
        )
    )
</div>