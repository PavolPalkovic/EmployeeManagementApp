<template>
  <div>
    <div v-if="componentName == 'componentCreate'">
      <CurrentCreate @closeCreate="componentName = ''"
      :getEmployeesParent="this.getEmployees"/>
    </div>
    <div v-if="componentName == 'componentDetails'">
      <CurrentDetails @closeDetails="componentName = ''"
      :firstName="this.employeeFirstName"
      :lastName="this.employeeLastName"
      :address="this.employeeAdress"
      :dateOfBirth="this.employeeDateOfBirth"
      :positionName="this.employeePosition"
      :startingDate="this.employeeStartingDate"
      :salary="this.employeeSalary"/>
    </div>
    <div v-if="componentName == 'componentEdit'">
      <CurrentEdit @closeEdit="componentName = ''"
      :id="this.employeeId"
      :firstName="this.employeeFirstName"
      :lastName="this.employeeLastName"
      :address="this.employeeAdress"
      :dateOfBirth="this.employeeDateOfBirth"
      :positionName="this.employeePosition"
      :startingDate="this.employeeStartingDate"
      :salary="this.employeeSalary"
      :getEmployeesParent="this.getEmployees"/>
    </div>
    <div v-if="componentName == 'componentDelete'">
      <CurrentDelete @closeDelete="componentName = ''"
      :id="this.employeeId"
      :firstName="this.employeeFirstName"
      :lastName="this.employeeLastName"
      :address="this.employeeAdress"
      :dateOfBirth="this.employeeDateOfBirth"
      :positionName="this.employeePosition"
      :startingDate="this.employeeStartingDate"
      :salary="this.employeeSalary"
      :getEmployeesParent="this.getEmployees"/>
    </div>
    <h1>Current Employees</h1>
    <button @click="showCreateComponent('componentCreate')">Create</button>
    <div>
      <table>
        <thead>
          <tr>
            <th>Name</th>
            <th>Position</th>
            <th>Options</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="employee in employees" :key="employee.id">
            <td class="underline-on-hover" @click="showComponent(employee, 'componentDetails')">{{ employee.firstName }} {{ employee.lastName }}</td>
            <td>{{ employee.positionName }}</td>
            <td>
              <button @click="showComponent(employee, 'componentEdit')">Edit</button>
              <button @click="showComponent(employee, 'componentDelete')">Delete</button>
            </td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
</template>

<script>
// Importing the component and naming it
import CurrentCreate from '../components/CurrentView/CurrentCreate.vue'
import CurrentDetails from '../components/CurrentView/CurrentDetails.vue'
import CurrentEdit from '../components/CurrentView/CurrentEdit.vue'
import CurrentDelete from '../components/CurrentView/CurrentDelete.vue'
import axios from 'axios'

export default {
  name: 'CurrentView',
  // Registring the component "CurrentDetails" and others from import
  components: {
    CurrentDetails, CurrentEdit, CurrentDelete, CurrentCreate
  },
  data() {
    return {
      employees: [
        // { id: "1", firstName: "Aaa", lastName: "Bbb", position: "cook" },
        // { id: "2", firstName: "Mmm", lastName: "Nnn", position: "cook" },
        // { id: "3", firstName: "Yyy", lastName: "Zzz", position: "waiter" }
      ],
      employeeId: 0,
      employeeFirstName: "",
      employeeLastName: "",
      employeeAdress: "",
      employeeDateOfBirth: "",
      employeePosition: "",
      employeeStartingDate: "",
      employeeSalary: "",
      componentName: ""
      }
  },
  mounted() {
    this.getEmployees();
  },
  methods: {
    getEmployees() {
      this.employees = [];
      axios.get('http://localhost:1028/api/employees')
        .then(response => {this.employees = response.data;
                          console.log(response)})
    },
    passValues(emp) {
      this.employeeId = emp.id;
      this.employeeFirstName = emp.firstName;
      this.employeeLastName = emp.lastName;
      this.employeeAdress = emp.address;
      this.employeeDateOfBirth = emp.dateOfBirth;
      this.employeePosition = emp.positionName;
      this.employeeStartingDate = emp.startingDate;
      this.employeeSalary = emp.salary;
    },
    showComponent(emp, componentName) {
      this.passValues(emp);
      this.componentName = componentName;
    },
    showCreateComponent(componentName) {
      this.componentName = componentName;
    }
  }
}
</script>

<style scoped>
  .underline-on-hover:hover {
    text-decoration: underline;
}
</style>