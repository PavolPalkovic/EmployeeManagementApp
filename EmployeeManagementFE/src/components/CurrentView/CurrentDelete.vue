<template>
    <div class="backdrop" @click.self="closeDelete">
        <div class="delete">
            <button @click="closeDelete">X</button>
            <h4>Do you want to archive {{ firstName }} {{ lastName }}?</h4>
            <button @click="archiveEmloyee(); reloadPage()">Archive And Delete</button>
            <button @click="deleteEmployee(); reloadPage()">Only Delete</button>
        </div>
    </div>
</template>

<script>
import axios from 'axios'

export default {
    props: ['id', 'firstName', 'lastName', 'address', 'dateOfBirth', 'positionName', 'startingDate', 'salary' ],
    data() {
        return {
            employeeData: {
                employeeId: this.id,
                firstName: this.firstName,
                lastName: this.lastName,
                address: this.address,
                dateOfBirth: this.dateOfBirth,
                positionName: this.positionName,
                startingDate: this.startingDate,
                salary: this.salary,
                dateOfDeletion: new Date().toISOString().split('T')[0]
            }
        }
    },
    methods: {
        // Custom event. Parent component listens to event named "closeDelete".
        // $emit('nameOfEvent')
        closeDelete() {
            this.$emit('closeDelete');
        },
        deleteEmployee() {
            axios.delete('http://localhost:1028/api/employees/' + this.id)
                .then(response => console.log(response))
                .catch(error => console.log(error))
        },
        reloadPage() {
            window.location.reload();
        },
        archiveEmloyee() {
            axios.post('http://localhost:1028/api/employeesHistory/', this.employeeData)
                .then(response => console.log(response))
                .catch(error => console.log(error))
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