import zipfile
import sys
import os
import itertools

unzip_path = './unzip'
characters = 'abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^&().'


class Guess:
    def check_file_exist(self, file_path):
        if os.path.exists(file_path):
            return True
        else:
            return False

    def create_unzip_dic(self, file_path):
        if not os.path.exists(file_path):
            os.makedirs(file_path)

    def extract_file(self, file_path, password):
        try:
            zip_ref = zipfile.ZipFile(file_path, 'r')
            self.create_unzip_dic(unzip_path)
            zip_ref.extractall(unzip_path, pwd=password.encode())
            zip_ref.close()
            return True
        except:
            return False
        return True
    
    def brute_force(self, Arg):
        length = 1
        while True and length <= len(characters):
            password_tuples = list(itertools.product(characters, repeat=length))
            for item in password_tuples:
                password_gen = ''.join(item)
                if self.extract_file(Arg, password_gen):
                    print("password is " + password_gen)
                    return
            length = length + 1
        print('can''t guess password')

    def __init__(self, Arg):
        if self.check_file_exist(Arg):
            self.brute_force(Arg)
        else:
            print("file not found")


def main():
    # guess = Guess(sys.argv[1])
    guess = Guess("aaaa.zip")

if __name__ == '__main__':
    main()
