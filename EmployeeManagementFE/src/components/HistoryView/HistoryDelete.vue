<template>
    <div class="backdrop" @click.self="close">
        <div class="delete">
            <h4>Do you really want to delete employee: {{ employee.firstName }} {{ employee.lastName }}</h4>
            <button @click="deleteEmployeeHistory(); close();">Yes</button>
            <button @click="close">Cancle</button>
        </div>
    </div>
</template>

<script>
import { deleteEmployeeHistory } from '../../requests/requestsHistory'

export default {
  props: ['employee', 'getEmployeesHistoryParent'],
  methods: {
    async deleteEmployeeHistory() {
      await deleteEmployeeHistory(this.employee.id);
      this.getEmployeesHistoryParent();
    },
    close() {
      this.$emit('closeDelete');
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