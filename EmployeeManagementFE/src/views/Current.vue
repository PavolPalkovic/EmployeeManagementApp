<template>
  <div>
    <div v-if="componentName == 'componentCreate'">
      <CurrentCreate @closeCreate="componentName = ''"
        :getEmployeesParent="this.getEmployees"/>
    </div>
    <div v-if="componentName == 'componentDetails'">
      <CurrentDetails @closeDetails="componentName = ''"
        :employee="this.employee"/>
    </div>
    <div v-if="componentName == 'componentEdit'">
      <CurrentEdit @closeEdit="componentName = ''"
        :employee="this.employee"
        :getEmployeesParent="this.getEmployees"/>
    </div>
    <div v-if="componentName == 'componentDelete'">
      <CurrentDelete @closeDelete="componentName = ''"
        :employee="this.employee"
        :getEmployeesParent="this.getEmployees"/>
    </div>
    <h1>Current Employees</h1>
    <button @click="showComponent('componentCreate')">Create</button>
    <div>
      <table>
        <thead>
          <tr>
            <th>Name</th>
            <th>Position</th>
            <th>Options</th>
          </tr>
        </thead>
        <tbody v-for="employee in employees" :key="employee.id">
          <tr>
            <td class="underline-on-hover" @click="passEmployee(employee); showComponent('componentDetails')">
              {{ employee.firstName }} {{ employee.lastName }}
            </td>
            <td>{{ employee.position.name }}</td>
            <td>
              <button @click="passEmployee(employee); showComponent('componentEdit')">Edit</button>
              <button @click="passEmployee(employee); showComponent('componentDelete')">Delete</button>
            </td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
</template>

<script>
// Importing the component and naming it
import CurrentCreate from "../components/CurrentView/CurrentCreate.vue";
import CurrentDetails from "../components/CurrentView/CurrentDetails.vue";
import CurrentEdit from "../components/CurrentView/CurrentEdit.vue";
import CurrentDelete from "../components/CurrentView/CurrentDelete.vue";
import { getEmployees } from "../requests/requestsCurrent";

export default {
  name: "CurrentView",
  // Registring the component "CurrentDetails" and others from import
  components: {
    CurrentDetails,
    CurrentEdit,
    CurrentDelete,
    CurrentCreate,
  },
  data() {
    return {
      employees: [],
      employee: {},
      componentName: "",
    };
  },
  mounted() {
    this.getEmployees();
  },
  methods: {
    async getEmployees() {
      this.employees = await getEmployees();
    },
    passEmployee(employee) {
      this.employee = employee;
    },
    showComponent(componentName) {
      this.componentName = componentName;
    }
  },
};
</script>

<style scoped>
.underline-on-hover:hover {
  text-decoration: underline;
}
</style>