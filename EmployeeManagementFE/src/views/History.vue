<template>
  <div>
    <div v-if="componentName == 'componentDelete'">
      <HistoryDelete @closeDelete="componentName = ''"
        :employee="this.employee"
        :getEmployeesHistoryParent="this.getEmployeesHistory"/>
    </div>
    <div v-if="componentName == 'componentDetails'">
      <HistoryDetails @closeDetails="componentName = ''"
        :employee="this.employee"/>
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
            <td class="underline-on-hover" @click="passEmployee(employee); showComponent('componentDetails')">{{ employee.firstName }} {{ employee.lastName }}</td>
            <td>{{ employee.position.name }}</td>
            <td>{{ employee.dateOfDeletion.split('T')[0] }}</td>
            <td>
              <button @click="passEmployee(employee); showComponent('componentDelete')">Delete</button>
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
import { getEmployeesHistory } from '../requests/requestsHistory'

export default {
  name: 'HistoryView',
  components: { 
    HistoryDelete, HistoryDetails
  },
  data() {
    return {
      employees: [],
      employee: {},
      componentName: ''
    }
  },
  mounted() {
    this.getEmployeesHistory();
  },
  methods: {
    async getEmployeesHistory() {
      this.employees = await getEmployeesHistory()
    },
    passEmployee(employee) {
      this.employee = employee;
    },
    showComponent(componentName) {
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