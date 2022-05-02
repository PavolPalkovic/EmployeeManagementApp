<template>
    <div class="backdrop" @click.self="close">
        <div class="create">
            <h4>*FirstName: <input type="text" v-model="employeeData.firstName"> </h4>
            <h4>*LastName: <input type="text" v-model="employeeData.lastName"> </h4>
            <h4>Address: <input type="text" v-model="employeeData.address"> </h4>
            <h4>*Date Of Birth:
                <input type="date" :max="new Date().toISOString().split('T')[0]" v-model="employeeData.dateOfBirth">
            </h4>
            <h4>*Position:
            <select @change="changePositionId($event)" >
                <option disabled selected value> -- select an option -- </option>
                <option v-for="position in positionData" :key="position.id" :value="position.id">{{ position.name }}</option>
            </select>
            </h4>
            <h4>*Starting Date:
                <input type="date" :min="new Date().toISOString().split('T')[0]" v-model="employeeData.startingDate">
            </h4>
            <h4>*Salary: <input type="number" v-model="employeeData.salary"> €</h4>
            <button @click="createEmployee(); close();"
                    :disabled="!employeeData.firstName || !employeeData.lastName || 
                    !employeeData.dateOfBirth || !employeeData.positionId ||
                    !employeeData.startingDate || !employeeData.salary">Create</button>
            <button @click="close">Cancle</button>
        </div>
    </div>
</template>

<script>
import axios from 'axios'

export default {
    props: ['getEmployeesParent'],
    data() {
        return {
            employeeData: {
                firstName: '',
                lastName: '',
                address: '',
                dateOfBirth: '',
                positionId: null,
                startingDate: '',
                salary: ''
            },
            positionData: []
        }
    },
    mounted() {
        this.getPositionData();
    },
    methods: {
        close() {
            this.$emit('closeCreate');
        },
        createEmployee() {
            this.changeDateFormat();
            console.log(this.employeeData.positionId);
            axios.post('http://localhost:1028/api/employees', this.employeeData)
                .then(response => console.log(response))
                .then(() => this.getEmployeesParent())
                .catch(error => console.log(error))
        },
        getPositionData() {
            fetch('http://localhost:1028/api/positions')
                .then(response => response.json())
                .then(data => {this.positionData = data})
        },
        changeDateFormat() {
            this.employeeData.dateOfBirth += "T00:00:00";
            this.employeeData.startingDate += "T00:00:00";
        },
        changePositionId(e) {
            this.employeeData.positionId = e.target.value;
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