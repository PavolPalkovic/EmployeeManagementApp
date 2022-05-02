import axios from 'axios'
//import { ref } from 'vue'


export function getEmployees(){
    return fetch('http://localhost:1028/api/employees')
            // response.json() is a Promise, returns either resolve or error 
            .then(response => response.json())
            .catch(error => console.log(error))
}

export function editEmployee(id, employeeData){
    return axios.put('http://localhost:1028/api/employees/' + id, employeeData)
            .then(response => console.log(response))
            .catch(error => console.log(error))
}

// export function changeDateFormat(arg) {
//     arg.forEach(date => {
//         date += "T00:00:00";
//     });
//}
