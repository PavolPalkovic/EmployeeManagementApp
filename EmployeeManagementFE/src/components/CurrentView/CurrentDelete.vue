<template>
  <div class="backdrop" @click.self="close">
    <div class="delete">
      <button @click="close">X</button>
      <h4>Do you want to archive {{ employee.firstName }} {{ employee.lastName }}?</h4>
      <button @click="archiveEmloyee(); close()">Archive And Delete</button>
      <button @click="deleteEmployee(); close()">Only Delete</button>
    </div>
  </div>
</template>

<script>
import { deleteEmployee } from "../../requests/requestsCurrent"
import { postEmployeeHistory } from "../../requests/requestsHistory"

export default {
  props: ['employee', 'getEmployeesParent'],
  mounted() {
    this.employee.dateOfDeletion = new Date().toISOString();
  },
  methods: {
    // Custom event. Parent component listens to event named "closeDelete".
    // $emit('nameOfEvent')
    close() {
      this.$emit('closeDelete');
    },
    async deleteEmployee() {
      await deleteEmployee(this.employee.id);
      this.getEmployeesParent();
    },
    async archiveEmloyee() {
      await postEmployeeHistory(this.employee);
      this.deleteEmployee();
    }
  }
}
</script>

<style scoped>
  .delete {
    width: 400px;
    padding: 20px;
    margin: 100px auto;
    background: white;
    border-radius: 10px;
  }
  .backdrop {
    top: 0;
    position: fixed;
    background: rgba(0,0,0,0.5);
    width: 100%;
    height: 100%;
  }
</style>