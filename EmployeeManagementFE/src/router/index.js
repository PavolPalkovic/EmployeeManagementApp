import { createRouter, createWebHistory } from 'vue-router'
import Current from '../views/Current.vue'
import History from '../views/History.vue'
import Positions from '../views/Positions.vue'
//import CurrentDetails from '../views/currentEmployees/CurrentDetails.vue'

const routes = [
  {
    path: '/',
    name: 'Current',
    component: Current
  },
  {
    path: '/history',
    name: 'History',
    component: History
  },
  {
    path: '/positions',
    name: 'Positions',
    component: Positions
  },
  // {
  //   path: '/:id',
  //   name: 'CurrentDetails',
  //   component: CurrentDetails
  // }
]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})

export default router
