
from django.conf.urls import url
from django.contrib import admin
from Upper import views

urlpatterns = [
    url(r'^admin/', admin.site.urls),
    url(r'^$', views.index),
    url(r'^someurl/', views.some)
]
