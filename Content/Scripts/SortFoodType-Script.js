$("document").ready(
    function () {
        $(".SortFoodType").click(
            function () {
                var typeID = $(this).attr("data-foodTypeID");
                $.ajax({
                    url: "/FoodByFoodType/GetFoodByType/?typeID=" + typeID,
                    method: "GET",
                    dataType: "html",
                    beforeSend: function () {
                        $(".loader1").removeClass("hidden");
                        $(".foodWrapper").addClass("hidden");
                    },
                    error: function () {
                        // your code here;
                    },
                    success: function (data) {
                        $(".foodWrapper").html(data);
                    },
                    complete: function () {
                        setTimeout(
                            function () {
                                $(".foodWrapper").removeClass("hidden");
                                $(".loader1").addClass("hidden");
                            }, 4000);
                    }
                });
            }
        );
    }
);

$("document").ready(
    function () {
        $(".specificFood").click(
            function () {
                var foodID = $(this).attr("data-specificFoodID");
                $.ajax({
                    url: "/SpecificFood/GetSpecificFood/?foodID=" + foodID,
                    method: "GET",
                    dataType: "html",
                    beforeSend: function () {
                        $(".loader2").removeClass("hidden");
                        $(".foodWrapper").addClass("hidden");
                    },
                    error: function () {
                        // your code here;
                    },
                    success: function (data) {
                        $(".foodWrapper").html(data);
                    },
                    complete: function () {
                        setTimeout(
                            function () {
                                $(".foodWrapper").removeClass("hidden");
                                $(".loader2").addClass("hidden");
                            }, 4000);
                    }
                });
            }
        );
    }
);