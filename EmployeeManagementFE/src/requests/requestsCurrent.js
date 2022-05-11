import axios from 'axios'

export const getEmployees = async () => {
  let employees = []

  try {
    let response = await axios.get('http://localhost:1028/api/employees/')
    console.log(response)
    if (!response.statusText == "OK")
      throw Error('No data available.')
    employees = response.data
  }
  catch (err) {
    console.log(err.message)
  }
  return employees
}


export const getEmployee = async (id) => {
  let employee = {}

  try {
    let response = await axios.get('http://localhost:1028/api/employees/' + id)
    console.log(response)
    if (!response.statusText == "OK")
      throw Error('No data available.')
    employee = response.data
    employee.startingDate = employee.startingDate.split("T")[0];
    employee.dateOfBirth = employee.dateOfBirth.split("T")[0]; 
  }
  catch (err) {
    console.log(err.message)
  }
  return employee
}

export const postEmployee = async (employee) => {
  employee.startingDate += "T00:00:00";
  employee.dateOfBirth += "T00:00:00";
  await axios.post('http://localhost:1028/api/employees/', employee)
    .then(response => console.log(response))
    .catch(error => console.log(error.message))
}

export const deleteEmployee = async (id) => {
  await axios.delete('http://localhost:1028/api/employees/' + id)
    .then(response => console.log(response))
    .catch(error => console.log(error.message))
}

export const putEmployee = async (id, employee) => {
  employee.startingDate += "T00:00:00";
  employee.dateOfBirth += "T00:00:00";
  await axios.put('http://localhost:1028/api/employees/' + id, employee)
    .then(response => console.log(response))
    .catch(error => console.log(error.message))
}
