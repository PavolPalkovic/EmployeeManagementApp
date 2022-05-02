<template>
    <div class="backdrop" @click.self="close">
        <div class="delete">
            <button @click="close">X</button>
            <h4>Do you want to archive {{ firstName }} {{ lastName }}?</h4>
            <button @click="archiveEmloyee(); close()">Archive And Delete</button>
            <button @click="deleteEmployee(); close()">Only Delete</button>
        </div>
    </div>
</template>

<script>
import axios from 'axios'

export default {
    props: ['id', 'firstName', 'lastName', 'address', 'dateOfBirth', 'positionId', 'position', 'startingDate', 'salary', 'getEmployeesParent'],
    data() {
        return {
            employeeData: {
                employeeId: this.id,
                firstName: this.firstName,
                lastName: this.lastName,
                address: this.address,
                dateOfBirth: this.dateOfBirth,
                positionId: this.positionId,
                position: this.position,
                startingDate: this.startingDate,
                salary: this.salary,
                dateOfDeletion: new Date().toISOString()
            }
        }
    },
    methods: {
        // Custom event. Parent component listens to event named "closeDelete".
        // $emit('nameOfEvent')
        close() {
            this.$emit('closeDelete');
        },
        deleteEmployee() {
            axios.delete('http://localhost:1028/api/employees/' + this.id)
                .then(response => console.log(response))
                .then(() => this.getEmployeesParent())
                .catch(error => console.log(error))
        },
        archiveEmloyee(dateOfDeletion) {
            this.changeDateFormat();
            axios.post('http://localhost:1028/api/employeesHistory/', this.employeeData)
                .then(response => console.log(response))
                .then(() => this.deleteEmployee())
                .catch(error => console.log(error))
        },
        changeDateFormat() {
            this.employeeData.dateOfBirth += "T00:00:00";
            this.employeeData.startingDate += "T00:00:00";
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