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
                        $(".loader").removeClass("hidden");
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
                                $(".loader").addClass("hidden");
                            }, 4000);
                    }
                });
            }
        );
    }
);