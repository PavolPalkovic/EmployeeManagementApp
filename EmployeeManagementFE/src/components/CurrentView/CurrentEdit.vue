<template>
    <div class="backdrop" @click.self="closeEdit">
        <div class="edit">
            <h4>*FirstName: <input type="text" v-model="employeeData.firstName"> </h4>
            <h4>*LastName: <input type="text" v-model="employeeData.lastName"> </h4>
            <h4>Address: <input type="text" v-model="employeeData.address"> </h4>
            <h4>*Date Of Birth:
                <input type="date" :max="new Date().toISOString().split('T')[0]" v-model="employeeData.dateOfBirth">
            </h4>
            <h4>*Position:
            <select v-model="employeeData.positionName" >
                <option v-for="position in positionData" :key="position.id">{{ position.name }}</option>
            </select>
            </h4>
            <h4>*Starting Date:
                <input type="date" :min="new Date().toISOString().split('T')[0]" v-model="employeeData.startingDate">
            </h4>
            <h4>*Salary: <input type="text" v-model="employeeData.salary"> €</h4>
            <button @click="editEmployee(); closeEdit(); reloadPage();"
                    :disabled="!employeeData.firstName || !employeeData.lastName || 
                    !employeeData.dateOfBirth || !employeeData.positionName ||
                    !employeeData.startingDate || !employeeData.salary">Edit</button>
            <button @click="closeEdit">Cancle</button>
        </div>
    </div>
</template>

<script>
import axios from 'axios'

export default {
    props: ['id', 'firstName', 'lastName', 'address', 'dateOfBirth', 'positionName', 'startingDate', 'salary' ],
    components: { },
    data() {
        return {
            employeeData: {
                firstName: this.firstName,
                lastName: this.lastName,
                address: this.address,
                dateOfBirth: this.dateOfBirth,
                positionName: this.positionName,
                startingDate: this.startingDate,
                salary: this.salary
            },
            positionData: [],
            currentDate: ''
        }
    },
    mounted() {
        this.getPositionData();
    },
    methods: {
        // Custom event. Parent component listens to event named "closeEdit".
        // $emit('nameOfEvent')
        closeEdit() {
            this.$emit('closeEdit');
        },
        editEmployee() {
            axios.put('http://localhost:1028/api/employees/' + this.id, this.employeeData)
                .then(response => console.log(response))
                .catch(error => console.log(error))
        },
        getPositionData() {
            fetch('http://localhost:1028/api/positions')
                .then(response => response.json())
                .then(data => {this.positionData = data})
        },
        reloadPage() {
            window.location.reload();
        },
        currentDateFormating() {
            const current = new Date();
            const currentDate = current.getFullYear()+'-'+(current.getMonth()+1)+'-'+current.getDate();
            return currentDate;
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