﻿var employee = document.getElementById("EmpSSN");
var projectsArea = document.getElementById("projectsArea");
var projectInput = document.getElementById("projNum");
var HourArea = document.getElementById("HourArea");
var inputHour = document.getElementById("Hours");



employee.addEventListener("change", async () => {

    
    var projectsResult = await fetch("http://localhost:5142/worksOnProject/EditEmployeeHour_emp/" + employee.value);
    projectList = await projectsResult.text();
    console.log(projectList);

    projectsArea.innerHTML = projectList;
    projectInput = document.getElementById("projNum");
    if (projectInput.value) {
        var hourResult = await fetch("http://localhost:5142/worksOnProject/EditEmployeeHour_emp_proj/" + employee.value + "?projNum=" + projectInput.value);
        hour = await hourResult.text();
        console.log(hour);
        HourArea.innerHTML = hour;
    }

    projectInput.addEventListener("change", async () => {

        console.log(projectInput);
        var hourResult = await fetch("http://localhost:5142/worksOnProject/EditEmployeeHour_emp_proj/" + employee.value + "?projNum=" + projectInput.value);
        hour = await hourResult.text();
        console.log(hour);
        HourArea.innerHTML = hour;
        //inputHour = document.getElementById("Hours");
        console.log(projectInput);

    });

});


