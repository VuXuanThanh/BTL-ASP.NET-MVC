$(".delBaseCate").click(function (e) {
    e.preventDefault();
    var id = $(this).attr("id");
    var MSG = confirm("Bạn có chắc muốn xóa danh mục này?");
    if (MSG) {
        $.ajax({
            type: 'POST',
            url: '/CategoryBases/Delete',
            data: { id: id },
            success: function (result) {
                if (result == true) {
                    alert("Xóa thành công")
                    setTimeout(function () { location.reload(); }, 1000);
                } else {
                    alert("Danh mục này có chứa các danh mục khác. Không thể xóa");
                }

            },
            error: function () {
                alert("Có lỗi khi xóa!");
            }
        });
    }

});


$(".addBaseCate").click(function (e) {
    e.preventDefault();
    var data = new Object();
    var formData = $('#formSubmit').serializeArray();
    $.each(formData, function (i, v) {
        $('#' + v.name + "2").text("");
        data["" + v.name + ""] = v.value;
        if (v.value == "") {
            $('#' + v.name+"2").text("Không được để trống trống");
        }
    });
    
        $.ajax({
            type: 'POST',
            url: '/CategoryBases/Create2',
            data: JSON.stringify(data),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (result) {
                if (result) {
                    alert("Thêm mới thành công")
                    $.each(formData, function (i, v) {
                        $('#' + v.name).val("");
                    });
                }
                else {
                    alert("Mã danh mục đã tồn tại")
                }

            },
            error: function () {
                alert("Có lỗi khi thêm!");
            }
        });

});


$(".editBaseCate").click(function (e) {
    e.preventDefault();
    var data = new Object();
    var formData = $('#formSubmit').serializeArray();
    $.each(formData, function (i, v) {
        $('#' + v.name + "2").text("");
        data["" + v.name + ""] = v.value;
        if (v.value == "") {
            $('#' + v.name + "2").text("Không được để trống");
        }
    });

    $.ajax({
        type: 'POST',
        url: '/CategoryBases/Edit2',
        data: JSON.stringify(data),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (result) {
            if (result) {
                alert("Sửa thành công")
                window.location.href = "https://localhost:44316/Admin/CategoryBases";
            }

        },
        error: function () {
            alert("Có lỗi khi thêm!");
        }
    });

});

