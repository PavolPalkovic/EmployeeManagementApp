import axios from 'axios'

export const getEmployeesHistory = async () => {
  let employees = []

  try {
    let response = await axios.get('http://localhost:1028/api/employeesHistory/')
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

export const postEmployeeHistory = async (employee) => {
  await axios.post('http://localhost:1028/api/employeesHistory/', employee)
    .then(response => console.log(response))
    .catch(error => console.log(error.message))
}

export const deleteEmployeeHistory = async (id) => {
  await axios.delete('http://localhost:1028/api/employeesHistory/' + id)
    .then(response => console.log(response))
    .catch(error => console.log(error.message))
}