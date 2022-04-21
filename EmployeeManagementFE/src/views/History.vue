<template>
  <div>
    <div v-if="componentName == 'componentDelete'">
      <HistoryDelete @closeDelete="componentName = ''"
      :id="this.employeeHistoryId"
      :firstName="this.employeeFirstName"
      :lastName="this.employeeLastName"/>
    </div>
    <div v-if="componentName == 'componentDetails'">
      <HistoryDetails @closeDetails="componentName = ''"
      :firstName="this.employeeFirstName"
      :lastName="this.employeeLastName"
      :address="this.employeeAdress"
      :dateOfBirth="this.employeeDateOfBirth"
      :positionName="this.employeePosition"
      :startingDate="this.employeeStartingDate"
      :salary="this.employeeSalary"/>
    </div>
      <h1>History Employees</h1>
      <div>
      <table>
        <thead>
          <tr>
            <th>Name</th>
            <th>Position</th>
            <th>Deletion Date</th>
            <th>Options</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="employee in employees" :key="employee.id">
            <td class="underline-on-hover" @click="showComponent(employee, 'componentDetails')">{{ employee.firstName }} {{ employee.lastName }}</td>
            <td>{{ employee.positionName }}</td>
            <td>{{ employee.dateOfDeletion }}</td>
            <td>
              <button @click="showComponent(employee, 'componentDelete')">Delete</button>
            </td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
</template>

<script>
import HistoryDelete from '../components/HistoryView/HistoryDelete.vue'
import HistoryDetails from '../components/HistoryView/HistoryDetails.vue'

export default {
  name: 'HistoryView',
  components: { HistoryDelete, HistoryDetails
  },
  data() {
    return {
      employees: [],
      employeeHistoryId: 0,
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
    fetch('http://localhost:1028/api/employeesHistory')
      .then(response => response.json())
      .then(data => {this.employees = data})
  },
  methods: {
    passValues(emp) {
      this.employeeHistoryId = emp.id;
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
    }
  }
}
</script>

<style scoped>
  .underline-on-hover:hover {
    text-decoration: underline;
}
</style>