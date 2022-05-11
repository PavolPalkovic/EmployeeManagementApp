<template>
  <div class="backdrop" @click.self="close">
    <div class="edit">
      <h4> *FirstName: <input type="text" v-model="employee.firstName" /></h4>
      <h4>*LastName: <input type="text" v-model="employee.lastName" /></h4>
      <h4>Address: <input type="text" v-model="employee.address" /></h4>
      <h4>*Date Of Birth: <input type="date" :max="new Date().toISOString().split('T')[0]" v-model="employee.dateOfBirth"/></h4>
      <h4>*Position:
        <select @change="changePositionId($event)">
          <option v-for="position in positions" :key="position.id" :selected="employee.positionId == position.id" :value="position.id">
            {{ position.name }}
          </option>
        </select>
      </h4>
      <h4>*Starting Date:<input type="date" :min="new Date().toISOString().split('T')[0]" v-model="employee.startingDate"/></h4>
      <h4>*Salary: <input type="number" v-model="employee.salary" /> €</h4>
      <button
        @click="editEmployee(); close()"
        :disabled="!employee.firstName || !employee.lastName || !employee.dateOfBirth || !employee.position.name || !employee.startingDate || !employee.salary">Edit</button>
      <button @click="close">Cancle</button>
    </div>
  </div>
</template>

<script>
import { putEmployee } from "../../requests/requestsCurrent";
import { getPositions } from "../../requests/requestsPosition";

export default {
  props: ["employee", "getEmployeesParent"],
  data() {
    return {
      positions: []
    };
  },
  async mounted() {
    this.employee.startingDate = this.employee.startingDate.split("T")[0];
    this.employee.dateOfBirth = this.employee.dateOfBirth.split("T")[0]; 
    this.positions = await getPositions();
  },
  methods: {
    async editEmployee() {
      await putEmployee(this.employee.id, this.employee)
      this.getEmployeesParent()
    },
    // Custom event. Parent component listens to event named "closeEdit".
    // $emit('nameOfEvent')
    close() {
      this.$emit("closeEdit");
    },
    changePositionId(e) {
      this.employee.positionId = parseInt(e.target.value);
    },
  },
};
</script>

<style scoped>
.edit {
  width: 400px;
  padding: 20px;
  margin: 100px auto;
  background: white;
  border-radius: 10px;
}
.backdrop {
  top: 0;
  position: fixed;
  background: rgba(0, 0, 0, 0.5);
  width: 100%;
  height: 100%;
}
</style>