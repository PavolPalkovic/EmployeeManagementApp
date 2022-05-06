<template>
    <div class="backdrop" @click.self="close">
        <div class="edit">
            <h4>*FirstName: <input type="text" v-model="employeeData.firstName"> </h4>
            <h4>*LastName: <input type="text" v-model="employeeData.lastName"> </h4>
            <h4>Address: <input type="text" v-model="employeeData.address"> </h4>
            <h4>*Date Of Birth:
                <input type="date" :max="new Date().toISOString().split('T')[0]" v-model="employeeData.dateOfBirth">
            </h4>
            <h4>*Position:
            <select @change="changePositionId($event)">
                <option v-for="position in positionData" :key="position.id" :selected="employeeData.positionId == position.id" :value="position.id">{{ position.name }}</option>
            </select>
            </h4>
            <h4>*Starting Date:
                <input type="date" :min="new Date().toISOString().split('T')[0]" v-model="employeeData.startingDate">
            </h4>
            <h4>*Salary: <input type="number" v-model="employeeData.salary"> €</h4>
            <button @click="editEmployee(this.id, this.employeeData).then(() => this.getEmployeesParent()); close();"
                    :disabled="!employeeData.firstName || !employeeData.lastName || 
                    !employeeData.dateOfBirth || !employeeData.position.name ||
                    !employeeData.startingDate || !employeeData.salary">Edit</button>
            <button @click="close">Cancle</button>
        </div>
    </div>
</template>

<script>
import axios from 'axios'
import { editEmployee } from '../../composables/requests'

export default {
    props: ['id', 'firstName', 'lastName', 'address', 'dateOfBirth', 'positionId', 'position', 'startingDate', 'salary', 'getEmployeesParent'],
    components: { },
    data() {
        return {
            employeeData: {
                firstName: this.firstName,
                lastName: this.lastName,
                address: this.address,
                dateOfBirth: this.dateOfBirth,
                positionId: this.positionId,
                position: this.position,
                startingDate: this.startingDate,
                salary: this.salary
            },
            positionData: [],
        }
    },
    mounted() {
        this.getPositionData();
    },
    methods: {
        editEmployee,
        // Custom event. Parent component listens to event named "closeEdit".
        // $emit('nameOfEvent')
        close() {
            this.$emit('closeEdit');
        },
        getPositionData() {
            fetch('http://localhost:1028/api/positions')
                .then(response => response.json())
                .then(data =>{this.positionData = data})
        },
        changePositionId(e) {
            this.employeeData.positionId = parseInt(e.target.value);
        }
    }
}
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
        background: rgba(0,0,0,0.5);
        width: 100%;
        height: 100%;
    }
</style>