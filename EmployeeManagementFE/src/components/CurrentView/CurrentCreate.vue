<template>
  <div class="backdrop" @click.self="close">
    <div class="create">
      <h4>*FirstName: <input type="text" v-model="employee.firstName"> </h4>
      <h4>*LastName: <input type="text" v-model="employee.lastName"> </h4>
      <h4>Address: <input type="text" v-model="employee.address"> </h4>
      <h4>*Date Of Birth:
        <input type="date" :max="new Date().toISOString().split('T')[0]" v-model="employee.dateOfBirth">
      </h4>
      <h4>*Position:
      <select @change="changePositionId($event)" >
        <option disabled selected value> -- select an option -- </option>
        <option v-for="position in positions" :key="position.id" :value="position.id">{{ position.name }}</option>
      </select>
      </h4>
      <h4>*Starting Date:
        <input type="date" :min="new Date().toISOString().split('T')[0]" v-model="employee.startingDate">
      </h4>
      <h4>*Salary: <input type="number" v-model="employee.salary"> €</h4>
      <button @click="createEmployee(); close();"
        :disabled="disableButton()">Create</button>
      <button @click="close">Cancle</button>
    </div>
  </div>
</template>

<script>
import { postEmployee } from "../../requests/requestsCurrent";
import { getPositions } from "../../requests/requestsPosition";

export default {
  props: ['getEmployeesParent'],
  data() {
    return {
      employee: {},
      positions: []
    }
  },
  async mounted() {
    this.positions = await getPositions();
  },
  methods: {
    async createEmployee() {
      await postEmployee(this.employee);
      this.getEmployeesParent();
    },
    close() {
      this.$emit('closeCreate');
    },
    changePositionId(e) {
      this.employee.positionId = parseInt(e.target.value);
    },
    disableButton() {
      return (!this.employee.firstName || !this.employee.lastName || 
        !this.employee.dateOfBirth || !this.employee.positionId ||
        !this.employee.startingDate || !this.employee.salary)
    }
  } 
}
</script>


<style scoped>
  .create {
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