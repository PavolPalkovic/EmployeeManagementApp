<template>
    <div class="backdrop" @click.self="closeCreate">
        <div class="create">
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
            <button @click="createEmployee(); closeCreate(); reloadPage();"
                    :disabled="!employeeData.firstName || !employeeData.lastName || 
                    !employeeData.dateOfBirth || !employeeData.positionName ||
                    !employeeData.startingDate || !employeeData.salary">Create</button>
            <button @click="closeCreate">Cancle</button>
        </div>
    </div>
</template>

<script>
import axios from 'axios'

export default {
    props: [ ],
    data() {
        return {
            employeeData: {
                firstName: '',
                lastName: '',
                address: '',
                dateOfBirth: '',
                positionName: '',
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
        closeCreate() {
            this.$emit('closeCreate');
        },
        createEmployee() {
            axios.post('http://localhost:1028/api/employees', this.employeeData)
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